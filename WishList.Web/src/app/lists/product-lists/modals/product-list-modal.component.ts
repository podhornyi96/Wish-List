import {Component, EventEmitter, Inject, Output, ViewChild} from '@angular/core';
import {ModalDirective} from 'ngx-bootstrap';
import {NgForm} from '@angular/forms';
import {APP_CONFIG, AppConfig} from '../../../app-config.module';
import {CookieService} from 'ngx-cookie-service';
import {FormHelper} from '../../../shared/helpers/form-helper';
import {ProductListService} from '../shared/product-list.service';
import {ProductList} from '../shared/product-list.model';
import {StoreService} from '../../../core/store/store.service';

declare var $: any;

@Component({
  selector: 'product-list-modal',
  templateUrl: './product-list-modal.component.html'
})
export class ProductListModalComponent {

  @ViewChild('productListModal') productListModal: ModalDirective;
  @ViewChild('productListForm') productListForm: NgForm;

  @Output() productListSaved: EventEmitter<ProductList> = new EventEmitter<ProductList>();

  public originalProductList: ProductList = new ProductList();
  public currentProductList: ProductList = new ProductList();

  public submitted = false;
  public loading = false;

  constructor(@Inject(APP_CONFIG) private config: AppConfig, private cookieService: CookieService,
              private productListService: ProductListService, private storeService: StoreService) {

  }

  public show(productList?: ProductList): void {
    this.originalProductList = productList ? productList : new ProductList();
    this.currentProductList = productList ? JSON.parse(JSON.stringify(productList)) : new ProductList();

    this.productListModal.show();
  }

  onHidden(): void {
    // const $productListSelect = $('#porductListSelect');
    //
    // if ($productListSelect.data('select2')) {
    //   $productListSelect.select2('destroy');
    // }
    //
    //
    // $productListSelect.off('select2:select');
    // $productListSelect.off('select2:unselect');

    this.submitted = false;
    this.productListForm.reset();
  }

  onShow(): void {
    // this.initProductListsSelect();
  }


  onSubmit(): void {
    this.submitted = true;

    if (!FormHelper.isFromValid(this.productListForm)) {
      return;
    }

    this.loading = true;

    this.currentProductList.OwnerId = this.cookieService.get('customerId');
    this.currentProductList.StoreId = this.storeService.getStore().Id;

    this.productListService.create(this.currentProductList).toPromise().then(data => {
      this.loading = false;
      Object.assign(this.originalProductList, data);

      if (!this.currentProductList.Id)
        this.productListSaved.emit(data);

      this.productListModal.hide();
    });
  }

}
