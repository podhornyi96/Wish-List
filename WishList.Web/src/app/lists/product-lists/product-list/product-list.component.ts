import {Component, Input} from '@angular/core';
import {ProductList} from '../shared/product-list.model';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html'
})
export class ProductListComponent {

  @Input() productList: ProductList;

}
