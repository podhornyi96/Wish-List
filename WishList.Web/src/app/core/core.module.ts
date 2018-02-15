import {CommonModule} from '@angular/common';
import {APP_INITIALIZER, NgModule} from '@angular/core';
import {SpinnerService} from './spinner/spinner.service';
import {SpinnerComponent} from './spinner/spinner.component';
import {CookieService} from 'ngx-cookie-service';
import {StoreService} from './store/store.service';

export function sotreProviderFactory(provider: StoreService) {
  return () => provider.load();
}

@NgModule({
  imports: [CommonModule],
  declarations: [SpinnerComponent],
  providers: [
    SpinnerService, CookieService, StoreService,

    {provide: APP_INITIALIZER, useFactory: sotreProviderFactory, deps: [StoreService], multi: true}
  ],
  exports: []
})
export class CoreModule {
}
