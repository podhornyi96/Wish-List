import {BaseSearchRequest} from '../../../shared/base-search-request.model';

export class ProductListSearchRequest extends BaseSearchRequest {

  Title: string;
  EventListId: number;
  StoreId: number;
  OwnerId: string;

  constructor(obj?: Partial<ProductListSearchRequest>) {
    super();
    Object.assign(this, obj);
  }

}

export enum ProductListSearchType {
  ByIds = 1,
  ByEventList = 2,
  AllByUser = 3
}
