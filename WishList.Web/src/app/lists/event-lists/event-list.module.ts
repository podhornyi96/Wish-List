import {ModuleWithProviders, NgModule} from '@angular/core';
import {EventListComponent} from './event-list.component';
import {RouterModule} from '@angular/router';
import {EventListModalComponent} from './modals/event-list-modal.component';
import {ModalModule} from 'ngx-bootstrap';
import {SharedModule} from '../../shared/shared.module';
import {EventListService} from './shared/event-list.service';
import {NgxPaginationModule} from 'ngx-pagination';
import {NgxMyDatePickerModule} from 'ngx-mydatepicker';

const childRouting: ModuleWithProviders = RouterModule.forChild([
  {path: '', redirectTo: 'lists/events', pathMatch: 'full'},
  {path: '', component: EventListComponent, data: {breadcrumb: 'Event'}}
]);

@NgModule({
  declarations: [EventListComponent, EventListModalComponent],
  imports: [
    SharedModule,

    ModalModule.forRoot(),
    NgxMyDatePickerModule.forRoot(),
    NgxPaginationModule,

    childRouting
  ],
  providers: [EventListService],
})
export class EventListModule {

}
