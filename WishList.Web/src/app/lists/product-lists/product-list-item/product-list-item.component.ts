import {Component, Input} from '@angular/core';
import {ProductItem} from '../shared/product-item.model';
import {ImageHelper} from '../shared/helpers/image-helper';

@Component({
  selector: 'product-list-item',
  templateUrl: './product-list-item.component.html'
})
export class ProductListItemComponent {

  @Input() productItem: ProductItem;

  imageHelper = ImageHelper;

}
