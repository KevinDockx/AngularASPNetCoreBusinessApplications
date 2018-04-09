import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/observable/of';
import { Band } from './band.model';
import { Manager } from './manager.model';
import { BaseService } from './base.service';


// Master data that's used across the application
@Injectable()
export class MasterDataService extends BaseService {

  private bands: Band[];
  private managers: Manager[];

  constructor(private http: HttpClient) {
    super();
  }

  getBands(): Observable<Band[]> {
    if (this.bands) {
      return Observable.of(this.bands);
    }
    else {
      return this.http.get<Band[]>(`${this.apiUrl}/bands`)
        .do((bandsFromResponse) => {
          this.bands = bandsFromResponse;
        });
    }
  }

  getManagers(): Observable<Manager[]> {
    if (this.managers) {
      return Observable.of(this.managers);
    }
    else {
      return this.http.get<Manager[]>(`${this.apiUrl}/managers`)
        .do((managersFromResponse) => {
          this.managers = managersFromResponse;
        });
    }
  }
}
