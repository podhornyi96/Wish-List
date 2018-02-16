import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {ProductList} from './shared/product-list.model';
import {ProductListService} from './shared/product-list.service';
import {EventListSearchRequest} from '../event-lists/shared/event-list-search-request.model';
import {Subject} from 'rxjs/Subject';
import {PaginationInstance} from 'ngx-pagination';
import {ProductListSearchRequest} from './shared/product-list-search-request.model';
import {CookieService} from 'ngx-cookie-service';
import {StoreService} from '../../core/store/store.service';

@Component({
  selector: 'product-lists',
  templateUrl: './product-lists.component.html',
  styleUrls: [
    '../../../assets/styles/pages/search.scss'
  ],
  encapsulation: ViewEncapsulation.None
})
export class ProductListsComponent implements OnInit {

  productLists: ProductList[] = [];

  load = true;
  title = '';

  pageConfig: PaginationInstance = {
    id: 'custom',
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0
  };

  private searchTerms = new Subject<EventListSearchRequest>();

  constructor(private productListService: ProductListService, private cookieService: CookieService, private storeService: StoreService) {

  }

  ngOnInit(): void {
    this.searchTerms
      .debounceTime(500)
      .distinctUntilChanged()
      .switchMap((request: ProductListSearchRequest) => this.productListService.search(request))
      .subscribe(response => {
        this.pageConfig.totalItems = response.TotalRows;
        this.productLists = response.Data;

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
      Top: this.pageConfig.itemsPerPage
    })).subscribe(response => {
      this.pageConfig.totalItems = response.TotalRows;
      this.pageConfig.currentPage = page;


      this.productLists = response.Data;

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
      Top: this.pageConfig.itemsPerPage
    }));
  }

  addList(productList: ProductList): void {
    this.pageConfig.totalItems++;

    if (this.productLists.length === this.pageConfig.itemsPerPage) {
      this.productLists.splice(-1, 1);
    }

    this.productLists.unshift(productList);
  }

  private updatePageConfig(): void { // TODO: move repeated code to base class
    const pageCount = this.pageConfig.totalItems / this.pageConfig.totalItems;

    if (this.pageConfig.currentPage === 1 && pageCount > 1) {
      this.pageConfig.currentPage++;
    } else if (this.pageConfig.currentPage > 1 && pageCount >= 1) {
      this.pageConfig.currentPage--;
    }
  }

  onProductListDelete(productList: ProductList): void {
    this.productLists.splice(this.productLists.indexOf(productList), 1);

    this.pageConfig.totalItems--;

    if (this.productLists.length === 0) {
      this.updatePageConfig();

      this.search(this.title);
    }
  }

}
