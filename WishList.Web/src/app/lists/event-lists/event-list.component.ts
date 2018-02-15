import {Component, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';
import {EventListModalComponent} from './modals/event-list-modal.component';
import {EventListService} from './shared/event-list.service';
import {EventListSearchRequest} from './shared/event-list-search-request.model';
import {EventList} from './shared/event-list.model';
import {PaginationInstance} from 'ngx-pagination';
import {Subject} from 'rxjs/Subject';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/distinctUntilChanged';
import {CookieService} from 'ngx-cookie-service';

@Component({
  selector: 'event-list',
  templateUrl: './event-list.component.html',
  styleUrls: [
    '../../../assets/styles/components/_event-lists.scss'
  ],
  encapsulation: ViewEncapsulation.None
})
export class EventListComponent implements OnInit {

  @ViewChild('eventListModal') eventListModal: EventListModalComponent;

  public title = '';

  public eventLists: EventList[] = [];

  private searchTerms = new Subject<EventListSearchRequest>();

  public load = false;

  constructor(private eventListService: EventListService, private cookieService: CookieService) {

  }

  public pageConfig: PaginationInstance = {
    id: 'custom',
    currentPage: 1,
    itemsPerPage: 2,
    totalItems: 0
  };

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
        this.eventLists = response.Data;

        this.load = false;
      });

    this.getPage(1);
  }

  getPage(page: number) {
    this.load = true;

    this.eventListService.search(new EventListSearchRequest({
      Title: this.title,
      OwnerId: this.cookieService.get('customerId'),
      Skip: (page - 1) * this.pageConfig.itemsPerPage,
      Top: this.pageConfig.itemsPerPage
    })).subscribe(response => {
      this.pageConfig.totalItems = response.TotalRows;
      this.pageConfig.currentPage = page;


      this.eventLists = response.Data;

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
      Skip: (this.pageConfig.currentPage - 1) * this.pageConfig.itemsPerPage,
      Top: this.pageConfig.itemsPerPage
    }));
  }

  delete(eventList: EventList): void {
    this.eventListService.delete(eventList.Id).toPromise().then(x => {
      this.eventLists.splice(this.eventLists.indexOf(eventList), 1);

      this.pageConfig.totalItems--;

      if (this.eventLists.length === 0) {
        this.updatePageConfig();

        this.search(this.title);
      }
    });
  }

  addList(eventList: EventList): void {
    this.pageConfig.totalItems++;

    if (this.eventLists.length === this.pageConfig.itemsPerPage)
      this.eventLists.splice(-1, 1);

    this.eventLists.unshift(eventList);
  }

  private updatePageConfig(): void {
    const pageCount = this.pageConfig.totalItems / this.pageConfig.totalItems;

    if (this.pageConfig.currentPage === 1 && pageCount > 1) {
      this.pageConfig.currentPage++;
    } else if (this.pageConfig.currentPage > 1 && pageCount >= 1) {
      this.pageConfig.currentPage--;
    }
  }

}
