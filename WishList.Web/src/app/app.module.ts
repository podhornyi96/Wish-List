import {BrowserModule} from '@angular/platform-browser';
import {ModuleWithProviders, NgModule} from '@angular/core';


import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {CommonModule} from '@angular/common';
import {AppConfigModule} from './app-config.module';
import {RouterModule} from '@angular/router';
import {ListsModule} from './lists/lists.module';
import {CoreModule} from './core/core.module';
import {LayoutComponent} from './layout/layout.component';
import {EventListModule} from './lists/event-lists/event-list.module';
import {ProductListModule} from './lists/product-lists/product-list.module';
import {TokenInterceptor} from './shared/token.interceptor';

const rootRouting: ModuleWithProviders = RouterModule.forRoot([

  {
    path: '',
    component: LayoutComponent, children: [
      {
        path: 'lists/events',
        loadChildren: 'app/lists/event-lists/event-list.module#EventListModule',
        data: {preload: true}
      },
      {
        path: 'lists/products',
        loadChildren: 'app/lists/product-lists/product-list.module#ProductListModule',
        // data: {preload: true}
      }
    ]
  }

]);

@NgModule({
  declarations: [
    AppComponent, LayoutComponent
  ],
  imports: [
    BrowserModule,
    CoreModule,
    HttpClientModule,
    CommonModule,


    AppConfigModule,
    EventListModule,
    ProductListModule,
    rootRouting

    // ListsModule
  ],
  providers: [
    // {
    //   provide: HTTP_INTERCEPTORS,
    //   useClass: TokenInterceptor,
    //   multi: true
    // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
