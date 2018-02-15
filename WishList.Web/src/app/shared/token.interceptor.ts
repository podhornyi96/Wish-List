import {Observable} from 'rxjs/Observable';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {CookieService} from 'ngx-cookie-service';

export class TokenInterceptor implements HttpInterceptor {

  constructor(private cookieService: CookieService) {

  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const changedReq = request.clone({
      setHeaders: {
        shop: this.cookieService.get('shop'),
        ownerId: this.cookieService.get('customerId')
      }
    });

    return next.handle(changedReq);
  }

}
