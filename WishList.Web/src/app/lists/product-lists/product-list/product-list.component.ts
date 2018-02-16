import {Component, EventEmitter, Input, Output, ViewEncapsulation} from '@angular/core';
import {ProductList} from '../shared/product-list.model';
import {ProductListModalComponent} from '../modals/product-list-modal.component';
import {ProductListService} from '../shared/product-list.service';
import {ProductItem} from '../shared/product-item.model';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
  encapsulation: ViewEncapsulation.None
})
export class ProductListComponent {

  @Input() productList: ProductList;
  @Input() productListModal: ProductListModalComponent;

  @Output() productListDeleted: EventEmitter<void> = new EventEmitter<void>();

  constructor(private productListService: ProductListService) {

  }

  removeProduct(productItem: ProductItem): void {
    this.productList.ProductItems.splice(this.productList.ProductItems.indexOf(productItem), 1);

    this.productListService.update(this.productList).subscribe(x => {
      Object.assign(this.productList, x);
    });
  }

  deleteList(): void {
    this.productListService.delete(this.productList.Id).subscribe(x => {
      this.productListDeleted.emit();
    });
  }

}
