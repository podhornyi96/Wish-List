import {ModuleWithProviders, NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {SharedModule} from '../../shared/shared.module';
import {NgxPaginationModule} from 'ngx-pagination';
import {ProductListsComponent} from './product-lists.component';
import {ProductListService} from './shared/product-list.service';
import {ProductListComponent} from './product-list/product-list.component';
import {ProductListItemComponent} from './product-list-item/product-list-item.component';
import {ProductListModalComponent} from './modals/product-list-modal.component';
import {ModalModule} from 'ngx-bootstrap';

const childRouting: ModuleWithProviders = RouterModule.forChild([
  // {path: '', redirectTo: 'events', pathMatch: 'full'},
  {path: '', component: ProductListsComponent, data: {breadcrumb: 'Product'}}
]);

@NgModule({
  declarations: [ProductListsComponent, ProductListComponent, ProductListItemComponent, ProductListModalComponent],
  imports: [
    SharedModule,

    ModalModule.forRoot(),
    NgxPaginationModule,

    childRouting
  ],
  providers: [ProductListService],
})
export class ProductListModule {

}
