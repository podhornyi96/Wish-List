import {Inject, Injectable} from '@angular/core';
import {BaseApiService} from '../../../core/base-api.service';
import {APP_CONFIG, AppConfig} from '../../../app-config.module';
import {HttpClient} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {Observable} from 'rxjs/Observable';
import {SearchResponse} from '../../../shared/search-response.model';
import {ProductListSearchRequest} from './product-list-search-request.model';
import {ProductList} from './product-list.model';

@Injectable()
export class ProductListService extends BaseApiService {

  constructor(public http: HttpClient, @Inject(APP_CONFIG) private config: AppConfig) {
    super();
  }

  public search(searchRequest: ProductListSearchRequest): Observable<SearchResponse<ProductList>> {
    return this.http.get(`${this.config.apiEndpoint}/lists/product`, {params: searchRequest as any}).pipe(
      tap(productLists => console.log('fetched product lists')),
      catchError(this.handleError<any>('search'))
    );
  }

  public create(productList: ProductList): Observable<ProductList> {
    return this.http.post(`${this.config.apiEndpoint}/lists/product`, productList).pipe(
      tap(x => console.log('created product list')),
      catchError(this.handleError<any>('searchProducts'))
    );
  }

  public update(productList: ProductList): Observable<ProductList> {
    return this.http.post(`${this.config.apiEndpoint}/lists/product/${productList.Id}`, productList).pipe(
      tap(x => console.log('created product list')),
      catchError(this.handleError<any>('searchProducts'))
    );
  }

  public delete(id: number): Observable<ProductList> {
    return this.http.delete(`${this.config.apiEndpoint}/lists/product/${id}`).pipe(
      tap(productList => console.log('created product list')),
      catchError(this.handleError<any>('searchProducts'))
    );
  }

}
