import { Injectable } from '@angular/core';
import { BaseService } from '../../../shared/base.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Show } from './show.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ShowService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  getShows(tourId: string): Observable<Show[]> {
    return this.http.get<Show[]>(`${this.apiUrl}/tours/${tourId}/shows`);
  }
}
