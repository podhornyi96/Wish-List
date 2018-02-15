import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {SpinnerService} from './spinner/spinner.service';
import {SpinnerComponent} from './spinner/spinner.component';
import {CookieService} from 'ngx-cookie-service';

@NgModule({
  imports: [CommonModule],
  declarations: [SpinnerComponent],
  providers: [SpinnerService, CookieService ],
  exports: []
})
export class CoreModule {
}
