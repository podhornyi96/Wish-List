import {Component, OnDestroy, OnInit, Renderer2, ViewEncapsulation} from '@angular/core';

declare var $: any;

@Component({
  selector: 'site-layout',
  templateUrl: './layout.component.html',
  styleUrls: [
    '../../assets/css/font-awesome/font-awesome.css',
    '../../assets/css/simple-line-icons/simple-line-icons.css',

    '../../assets/styles/bootstrap.scss',
    // '../../assets/styles/global/plugins/_bootstrap-switch.scss',

    '../../assets/styles/global/components.scss',

    '../../assets/styles/layouts/layout.scss',
    '../../assets/styles/layouts/layout/themes/darkblue.scss',
    '../../assets/styles/layouts/layout/custom.scss',
  ],
  encapsulation: ViewEncapsulation.None
})
export class LayoutComponent implements OnDestroy {

  constructor(private renderer: Renderer2) {
    this.renderer.addClass(document.body, 'page-header-fixed');
    this.renderer.addClass(document.body, 'page-sidebar-closed-hide-logo');
    this.renderer.addClass(document.body, 'page-content-white');
  }

  ngOnDestroy() {
    this.renderer.removeClass(document.body, 'page-header-fixed');
    this.renderer.removeClass(document.body, 'page-sidebar-closed-hide-logo');
    this.renderer.removeClass(document.body, 'page-content-white');
  }

}
