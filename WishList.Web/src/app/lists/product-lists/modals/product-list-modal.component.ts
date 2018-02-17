import {AfterViewInit, Component, EventEmitter, Inject, Output, ViewChild} from '@angular/core';
import {ModalDirective} from 'ngx-bootstrap';
import {NgForm} from '@angular/forms';
import {APP_CONFIG, AppConfig} from '../../../app-config.module';
import {CookieService} from 'ngx-cookie-service';
import {FormHelper} from '../../../shared/helpers/form-helper';
import {ProductListService} from '../shared/product-list.service';
import {ProductList} from '../shared/product-list.model';
import {StoreService} from '../../../core/store/store.service';
import {ImageHelper} from '../shared/helpers/image-helper';
import {ProductItem} from '../shared/product-item.model';
import {BaseList} from '../shared/base-list.model';

declare var $: any;

@Component({
  selector: 'product-list-modal',
  templateUrl: './product-list-modal.component.html'
})
export class ProductListModalComponent implements AfterViewInit {

  @ViewChild('productListModal') productListModal: ModalDirective;
  @ViewChild('productListForm') productListForm: NgForm;

  @Output() productListSaved: EventEmitter<ProductList> = new EventEmitter<ProductList>();

  originalProductList: ProductList = new ProductList();
  currentProductList: ProductList = new ProductList();

  submitted = false;
  loading = false;

  selectedProduct: any;

  imageHelper = ImageHelper;

  constructor(@Inject(APP_CONFIG) private config: AppConfig, private cookieService: CookieService,
              private productListService: ProductListService, private storeService: StoreService) {

  }

  ngAfterViewInit(): void {
    this.initProductSelect();
  }

  public show(productList?: ProductList): void {
    this.originalProductList = productList ? productList : new ProductList();
    this.currentProductList = productList ? JSON.parse(JSON.stringify(productList)) : new ProductList();

    this.productListModal.show();
  }

  onHidden(): void {
    this.submitted = false;
    $('#productsSelect').val('').trigger('change');
    this.productListForm.reset();
  }

  onShow(): void {

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

      if (!this.currentProductList.Id) {
        this.productListSaved.emit(data);
      }

      this.productListModal.hide();
    });
  }

  public addProduct(): void {
    this.currentProductList.ProductItems.push(new ProductItem({
      VariantId: this.selectedProduct.variant,
      ProductId: this.selectedProduct.product.id,
      ProductListId: this.currentProductList.Id,
      Product: this.selectedProduct.product
    }));

    this.selectedProduct = null;

    $('#productsSelect').val('').trigger('change');
  }

  private initProductSelect(): void {
    const $productSelect = $('#productsSelect');

    const self = this;

    $productSelect.select2({
      width: '100%',
      data: [],
      allowClear: true,
      placeholder: 'Select product',
      minimumInputLength: 2,
      dropdownParent: $('#productListForm'),
      ajax: {
        url: this.config.apiEndpoint + '/product',
        datatype: 'json',
        delay: 500,
        data: function (params: any) {
          return {
            title: params.term,
            storeId: self.storeService.getStore().Id,
            page: (params.page || 1),
            limit: 10
          };
        },
        processResults: function (response: any[], params: any): any {
          if (!response) {
            return [];
          }

          const results: any[] = self.getProductVariants(response);

          return {
            results: results
          };
        }
      },
      templateResult: function formatState(state: any) {
        if (!state.id) {
          return state.text;
        }

        const $state = $(
          '<div style="display: flex;">' +
          '<div style="width: 26%; height: 100px; background-size: cover; background-position: center center; background-image: url(' + state.imageSrc + ')" class="img-flag" />' +
          '<div style="display: inline-block; margin-left: 20px; width: 74%; height: 92px; overflow: hidden;text-overflow: ellipsis; white-space: nowrap;">' +
          '<h3 style="font-size: 15px">' + state.text + '</h3>' +
          '</div>' +
          '</div>' +
          '</div>'
        );

        return $state;
      },
    }).on('select2:select', function (e: any) {
      self.selectedProduct = e.params.data;
    }).on('select2:unselect', function (e: any) {
      self.selectedProduct = null;
    });
  }

  private hasProduct(productData: any): boolean {
    if (!productData) {
      return true;
    }

    for (const product of this.currentProductList.ProductItems) {
      if (product.VariantId === productData.variant && product.ProductId === productData.product.id) {
        return true;
      }
    }

    return false;
  }

  private getProductVariants(products: any[]): any[] {
    const result: any[] = [];

    for (const product of products) {
      for (const variant of product.variants) {
        result.push({
          id: variant.product_id + '-' + variant.id,
          text: `${product.title}-${variant.id}`,
          variant: variant.id,
          product: product,
          imageSrc: ImageHelper.getProductImage(product, variant)
        });
      }
    }

    return result;
  }

}
