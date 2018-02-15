import {Inject, Injectable} from '@angular/core';
import {APP_CONFIG, AppConfig} from '../../../app-config.module';
import {HttpClient} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {Observable} from 'rxjs/Observable';
import {of} from 'rxjs/observable/of';
import {EventList} from './event-list.model';
import {SearchResponse} from '../../../shared/search-response.model';
import {EventListSearchRequest} from './event-list-search-request.model';
import {BaseApiService} from '../../../core/base-api.service';


@Injectable()
export class EventListService extends BaseApiService {

  constructor(public http: HttpClient, @Inject(APP_CONFIG) private config: AppConfig) {
    super();
  }

  public search(searchRequest: EventListSearchRequest): Observable<SearchResponse<EventList>> {
    return this.http.get(`${this.config.apiEndpoint}/lists/event`, {params: searchRequest as any}).pipe(
      tap(eventLists => console.log('fetched event lists')),
      catchError(this.handleError<any>('search'))
    );
  }

  public create(eventList: EventList): Observable<EventList> {
    return this.http.post(`${this.config.apiEndpoint}/lists/event`, eventList).pipe(
      tap(eventList => console.log('created event list')),
      catchError(this.handleError<any>('searchProducts'))
    );
  }

  public delete(id: number): Observable<EventList> {
    return this.http.delete(`${this.config.apiEndpoint}/lists/event/${id}`).pipe(
      tap(eventList => console.log('created event list')),
      catchError(this.handleError<any>('searchProducts'))
    );
  }


}
