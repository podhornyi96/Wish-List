import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {ProductList} from './shared/product-list.model';
import {ProductListService} from './shared/product-list.service';
import {ProductListSearchRequest, ProductListSearchType} from './shared/product-list-search-request.model';
import {CookieService} from 'ngx-cookie-service';
import {StoreService} from '../../core/store/store.service';
import {BaseList} from './shared/base-list.model';

@Component({
  selector: 'product-lists',
  templateUrl: './product-lists.component.html',
  styleUrls: [
    '../../../assets/styles/pages/search.scss'
  ],
  encapsulation: ViewEncapsulation.None
})
export class ProductListsComponent extends BaseList<ProductList> implements OnInit {

  constructor(private productListService: ProductListService, private cookieService: CookieService, private storeService: StoreService) {
    super(5);
  }

  ngOnInit(): void {
    this.searchTerms
      .debounceTime(500)
      .distinctUntilChanged()
      .switchMap((request: ProductListSearchRequest) => this.productListService.search(request))
      .subscribe(response => {
        this.pageConfig.totalItems = response.TotalRows;
        this.lists = response.Data;

        this.load = false;
      });

    this.getPage(1);
  }

  getPage(page: number) {
    this.load = true;

    this.productListService.search(new ProductListSearchRequest({
      Title: this.title,
      OwnerId: this.cookieService.get('customerId'),
      StoreId: this.storeService.getStore().Id,
      Skip: (page - 1) * this.pageConfig.itemsPerPage,
      Top: this.pageConfig.itemsPerPage,
      SearchType: ProductListSearchType.AllByUser
    })).subscribe(response => {
      this.pageConfig.totalItems = response.TotalRows;
      this.pageConfig.currentPage = page;


      this.lists = response.Data;

      this.load = false;
    });
  }

  search(title: string): void {
    this.load = true;

    if (this.title !== title) {
      this.pageConfig.currentPage = 1;
    }

    this.title = title;

    this.searchTerms.next(new ProductListSearchRequest({
      Title: title,
      OwnerId: this.cookieService.get('customerId'),
      StoreId: this.storeService.getStore().Id,
      Skip: (this.pageConfig.currentPage - 1) * this.pageConfig.itemsPerPage,
      Top: this.pageConfig.itemsPerPage,
      SearchType: ProductListSearchType.AllByUser
    }));
  }

  onProductListDelete(productList: ProductList): void {
    this.lists.splice(this.lists.indexOf(productList), 1);

    this.pageConfig.totalItems--;

    if (this.lists.length === 0) {
      this.updatePageConfig();

      this.search(this.title);
    }
  }

}
