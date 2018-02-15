import {Inject, Injectable} from '@angular/core';
import {BaseApiService} from '../base-api.service';
import {APP_CONFIG, AppConfig} from '../../app-config.module';
import {HttpClient} from '@angular/common/http';
import {Store} from './store.model';
import {StringHelper} from '../../shared/helpers/string-helper';

@Injectable()
export class StoreService extends BaseApiService {

  private store: Store = null;

  constructor(public http: HttpClient, @Inject(APP_CONFIG) private config: AppConfig) {
    super();
  }

  public getStore(): Store {
    return this.store;
  }

  load() {
    return new Promise<Store>((resolve, reject) => {
      const param = StringHelper.replaceHttpPrefix(StringHelper.getParameterByName('shop')); // TODO : move to normal helper

      this.http
        .get<Store>(`${this.config.apiEndpoint}/store?shop=${param}`)
        .subscribe(store => {
          this.store = store;
          resolve(store);
        });
    });
  }

}
