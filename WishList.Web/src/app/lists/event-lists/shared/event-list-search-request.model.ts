import {BaseSearchRequest} from '../../../shared/base-search-request.model';

export class EventListSearchRequest extends BaseSearchRequest {

  Title: string;
  OwnerId: string;
  StoreId: number;

  constructor(obj?: Partial<EventListSearchRequest>) {
    super();
    Object.assign(this, obj);
  }

}
