import {PaginationInstance} from 'ngx-pagination';
import {Subject} from 'rxjs/Subject';
import {EventListSearchRequest} from '../../event-lists/shared/event-list-search-request.model';

export class BaseList<T> {

  lists: T[] = [];

  load = true;
  title = '';

  pageConfig: PaginationInstance = {
    id: 'custom',
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0
  };

  public searchTerms = new Subject<EventListSearchRequest>();

  constructor(itemsPerPage: number) {
    this.pageConfig.itemsPerPage = itemsPerPage;
  }

  addList(productList: T): void {
    this.pageConfig.totalItems++;

    if (this.lists.length === this.pageConfig.itemsPerPage) {
      this.lists.splice(-1, 1);
    }

    this.lists.unshift(productList);
  }

  updatePageConfig(): void {
    const pageCount = this.pageConfig.totalItems / this.pageConfig.totalItems;

    if (this.pageConfig.currentPage === 1 && pageCount > 1) {
      this.pageConfig.currentPage++;
    } else if (this.pageConfig.currentPage > 1 && pageCount >= 1) {
      this.pageConfig.currentPage--;
    }
  }

}
