import {BaseSearchRequest} from '../../../shared/base-search-request.model';

export class EventListSearchRequest extends BaseSearchRequest {

  Title: string;
  OwnerId: string;

  constructor(obj?: Partial<EventListSearchRequest>) {
    super();
    Object.assign(this, obj);
  }

}
