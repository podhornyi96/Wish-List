import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {LayoutComponent} from './layout/layout.component';

@NgModule({
  imports: [CommonModule, LayoutComponent],
  declarations: [],
  providers: [],
  exports: [
    CommonModule,
    FormsModule
  ]
})
export class SharedModule {
}
