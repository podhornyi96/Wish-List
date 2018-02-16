import {Component, EventEmitter, Input, Output, ViewEncapsulation} from '@angular/core';
import {ProductItem} from '../shared/product-item.model';
import {ImageHelper} from '../shared/helpers/image-helper';

@Component({
  selector: 'product-list-item',
  templateUrl: './product-list-item.component.html',
  encapsulation: ViewEncapsulation.None
})
export class ProductListItemComponent {

  @Input() productItem: ProductItem;

  @Output() productItemRemoved: EventEmitter<ProductItem> = new EventEmitter<ProductItem>();
  @Output() editList: EventEmitter<void> = new EventEmitter<void>();

  imageHelper = ImageHelper;

  remove(): void {
    this.productItemRemoved.emit(this.productItem);
  }

  edit(): void {
    this.editList.emit();
  }

}
