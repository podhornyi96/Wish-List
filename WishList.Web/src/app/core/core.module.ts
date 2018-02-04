import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {SpinnerService} from './spinner/spinner.service';
import {SpinnerComponent} from './spinner/spinner.component';

@NgModule({
  imports: [CommonModule],
  declarations: [SpinnerComponent],
  providers: [SpinnerService],
  exports: []
})
export class CoreModule {
}
