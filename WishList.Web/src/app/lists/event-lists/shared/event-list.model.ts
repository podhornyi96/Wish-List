import {BaseEntity} from '../../../shared/base-entity.model';
import {ProductList} from '../../product-lists/shared/product-list.model';

export class EventList extends BaseEntity<number> {
  OwnerId: string;
  StoreId: number;
  Title: string;
  Description: string;
  Date: Date;
  ProductLists: ProductList[] = [];
}
