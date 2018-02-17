import {Component, EventEmitter, Inject, Output, ViewChild} from '@angular/core';
import {ModalDirective} from 'ngx-bootstrap';
import {EventList} from '../shared/event-list.model';
import {NgForm} from '@angular/forms';
import {ProductList} from '../../product-lists/shared/product-list.model';
import {APP_CONFIG, AppConfig} from '../../../app-config.module';
import {SearchResponse} from '../../../shared/search-response.model';
import {CookieService} from 'ngx-cookie-service';
import {EventListService} from '../shared/event-list.service';
import {FormHelper} from '../../../shared/helpers/form-helper';
import {StoreService} from '../../../core/store/store.service';
import {ProductListSearchType} from '../../product-lists/shared/product-list-search-request.model';
import {IMyInputFieldChanged, INgxMyDpOptions} from 'ngx-mydatepicker';

declare var $: any;

@Component({
  selector: 'event-list-modal',
  templateUrl: './event-list-modal.component.html'
})
export class EventListModalComponent {

  @ViewChild('eventListModal') eventListModal: ModalDirective;
  @ViewChild('eventListForm') eventListForm: NgForm;

  @Output() eventListSaved: EventEmitter<EventList> = new EventEmitter<EventList>();

  originalEventList: EventList = new EventList();
  currentEventList: EventList = new EventList();

  submitted = false;
  loading = false;

  selectedDate: any = {date: {year: new Date().getFullYear(), month: new Date().getMonth() + 1, day: new Date().getDate()}};

  myOptions: INgxMyDpOptions = {
    dateFormat: 'dd.mm.yyyy',
    disableUntil: {year: new Date().getFullYear(), month: new Date().getMonth() + 1, day: new Date().getDate()}
  };

  constructor(@Inject(APP_CONFIG) private config: AppConfig, private cookieService: CookieService,
              private eventListService: EventListService, private storeService: StoreService) {
    console.log(this.cookieService.get('customerId'));
  }

  public show(eventList?: EventList): void {
    this.originalEventList = eventList ? eventList : new EventList();
    this.currentEventList = eventList ? JSON.parse(JSON.stringify(eventList)) : new EventList();

    this.eventListModal.show();
  }

  onHidden(): void {
    const $productListSelect = $('#porductListSelect');

    if ($productListSelect.data('select2')) {
      $productListSelect.select2('destroy');
    }


    $productListSelect.off('select2:select');
    $productListSelect.off('select2:unselect');

    this.submitted = false;
    this.eventListForm.reset();
  }

  onShow(): void {

    if (this.currentEventList.Date) {
      const date = new Date(this.currentEventList.Date);

      this.eventListForm.form.patchValue({
        date: {
          date: {
            year: date.getFullYear(),
            month: date.getMonth() + 1,
            day: date.getDate()
          }
        }
      });
    }


    this.initProductListsSelect();
  }

  onInputFieldChanged(event: IMyInputFieldChanged) {
    if (!event.valid) {
      this.selectedDate = null;
    }
  }

  private initProductListsSelect(): void {
    const $productListSelect: any = $('#porductListSelect');

    const self = this;

    const data = this.currentEventList.ProductLists.map(x => {
      return {
        id: x.Id,
        text: x.Title,
        item: x
      };
    });

    $productListSelect.html('').select2({
      width: '100%',
      data: data,
      allowClear: true,
      placeholder: 'Select lists',
      multiple: 'multiple',
      dropdownParent: $('#producListForm'),
      ajax: {
        url: this.config.apiEndpoint + '/lists/product',
        datatype: 'json',
        delay: 500,
        data: function (params: any) {
          return {
            skip: ((params.page || 1) - 1) * 10,
            top: 10,
            searchType: ProductListSearchType.ByEventList,
            eventListId: self.currentEventList.Id,
            ownerId: self.cookieService.get('customerId'),
            storeId: self.storeService.getStore().Id,
            title: params.term
          };
        },
        processResults: function (response: SearchResponse<ProductList>, params: any): any {
          if (!response || !response.Data) {
            return [];
          }

          const results: any[] = response.Data.map(function (productList) {
            return {
              id: productList.Id,
              text: productList.Title,
              item: productList
            };
          });

          params.page = params.page || 1;

          return {
            results: results,
            pagination: {
              more: (params.page * 10) < response.TotalRows
            }
          };
        }
      },
    }).on('select2:select', function (e: any) {
      self.currentEventList.ProductLists.push(e.params.data.item);
    }).on('select2:unselect', function (e: any) {
      self.currentEventList.ProductLists = self.currentEventList.ProductLists.filter(x => x.Id !== e.params.data.item.Id);
    });

    $productListSelect.val(this.currentEventList.ProductLists.map(x => x.Id)).trigger('change');
  }

  onSubmit(): void {
    this.submitted = true;

    if (!FormHelper.isFromValid(this.eventListForm)) {
      return;
    }

    this.loading = true;

    this.currentEventList.OwnerId = this.cookieService.get('customerId');
    this.currentEventList.StoreId = this.storeService.getStore().Id;

    if (this.selectedDate != null) { // TODO: refactor this
      const date = new Date();

      date.setFullYear(this.selectedDate.date.year);
      date.setMonth(this.selectedDate.date.month - 1);
      date.setDate(this.selectedDate.date.day);

      this.currentEventList.Date = date;
    }

    this.eventListService.create(this.currentEventList).toPromise().then(data => {
      this.loading = false;
      Object.assign(this.originalEventList, data);

      if (!this.currentEventList.Id) {
        this.eventListSaved.emit(data);
      }

      this.eventListModal.hide();
    });
  }

}
