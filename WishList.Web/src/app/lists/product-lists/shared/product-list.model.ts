import {BaseEntity} from '../../../shared/base-entity.model';
import {ProductItem} from './product-item.model';

export class ProductList extends BaseEntity<number> {

  OwnerId: string;
  StoreId: number;
  EventListId: number;
  Title: string;
  ProductItems: ProductItem[] = [];

}
