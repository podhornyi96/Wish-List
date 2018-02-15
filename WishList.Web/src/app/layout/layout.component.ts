import {Component, OnDestroy, OnInit, Renderer2, ViewEncapsulation} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {CookieService} from 'ngx-cookie-service';

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

    '../../assets/css/select2/select2.css',
    '../../assets/css/select2/select2-bootstrap.min.css'
  ],
  encapsulation: ViewEncapsulation.None
})
export class LayoutComponent implements OnInit, OnDestroy {

  constructor(private renderer: Renderer2, private route: ActivatedRoute, private cookieService: CookieService) {
    this.renderer.addClass(document.body, 'page-header-fixed');
    this.renderer.addClass(document.body, 'page-sidebar-closed-hide-logo');
    this.renderer.addClass(document.body, 'page-content-white');
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.cookieService.set('customerId', params['customerId']);
      this.cookieService.set('shop', params['shop']);
    }).unsubscribe();
  }

  ngOnDestroy() {
    this.renderer.removeClass(document.body, 'page-header-fixed');
    this.renderer.removeClass(document.body, 'page-sidebar-closed-hide-logo');
    this.renderer.removeClass(document.body, 'page-content-white');
  }

}
