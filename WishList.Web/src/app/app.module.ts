import {BrowserModule} from '@angular/platform-browser';
import {ModuleWithProviders, NgModule} from '@angular/core';


import {AppComponent} from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {CommonModule} from '@angular/common';
import {AppConfigModule} from './app-config.module';
import {RouterModule} from '@angular/router';
import {ListsModule} from './lists/lists.module';
import {CoreModule} from './core/core.module';
import {LayoutComponent} from './layout/layout.component';

const rootRouting: ModuleWithProviders = RouterModule.forRoot([
  {path: '', component: LayoutComponent}
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
    ListsModule,
    rootRouting,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
