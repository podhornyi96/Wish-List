import {Component, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';
import {EventListModalComponent} from './modals/event-list-modal.component';
import {EventListService} from './shared/event-list.service';
import {EventListSearchRequest} from './shared/event-list-search-request.model';
import {EventList} from './shared/event-list.model';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/distinctUntilChanged';
import {CookieService} from 'ngx-cookie-service';
import {StoreService} from '../../core/store/store.service';
import {BaseList} from '../product-lists/shared/base-list.model';

@Component({
  selector: 'event-list',
  templateUrl: './event-list.component.html',
  encapsulation: ViewEncapsulation.None
})
export class EventListComponent extends BaseList<EventList> implements OnInit {

  @ViewChild('eventListModal') eventListModal: EventListModalComponent;

  constructor(private eventListService: EventListService, private cookieService: CookieService, private storeService: StoreService) {
    super(5);
  }

  get itemsPerPage() {
    return this.pageConfig.itemsPerPage;
  }

  set itemsPerPage(value: number) {
    this.pageConfig.itemsPerPage = value;

    this.search(this.title);
  }

  ngOnInit() {
    this.searchTerms
      .debounceTime(500)
      .distinctUntilChanged()
      .switchMap((request: EventListSearchRequest) => this.eventListService.search(request))
      .subscribe(response => {
        this.pageConfig.totalItems = response.TotalRows;
        this.lists = response.Data;

        this.load = false;
      });

    this.getPage(1);
  }

  getPage(page: number) {
    this.load = true;

    this.eventListService.search(new EventListSearchRequest({
      Title: this.title,
      OwnerId: this.cookieService.get('customerId'),
      StoreId: this.storeService.getStore().Id,
      Skip: (page - 1) * this.pageConfig.itemsPerPage,
      Top: this.pageConfig.itemsPerPage
    })).subscribe(response => {
      this.pageConfig.totalItems = response.TotalRows;
      this.pageConfig.currentPage = page;


      this.lists = response.Data;

      this.load = false;
    });
  }

  search(title: string): void {
    this.load = true;

    if (this.title !== title) {
      this.pageConfig.currentPage = 1;
    }

    this.title = title;

    this.searchTerms.next(new EventListSearchRequest({
      Title: title,
      OwnerId: this.cookieService.get('customerId'),
      StoreId: this.storeService.getStore().Id,
      Skip: (this.pageConfig.currentPage - 1) * this.pageConfig.itemsPerPage,
      Top: this.pageConfig.itemsPerPage
    }));
  }

  delete(eventList: EventList): void {
    this.eventListService.delete(eventList.Id).toPromise().then(x => {
      this.lists.splice(this.lists.indexOf(eventList), 1);

      this.pageConfig.totalItems--;

      if (this.lists.length === 0) {
        this.updatePageConfig();

        this.search(this.title);
      }
    });
  }

}
