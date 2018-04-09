import { Injectable } from '@angular/core';
import { BaseService } from '../../../shared/base.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Show } from './show.model';
import { Observable } from 'rxjs/Observable';
import { ShowForCreation } from './show-for-creation.model';

@Injectable()
export class ShowService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  getShows(tourId: string): Observable<Show[]> {
    return this.http.get<Show[]>(`${this.apiUrl}/tours/${tourId}/shows`);
  }

  addShowCollection(tourId: string, showsToAdd: ShowForCreation[]): Observable<Show[]> {
    return this.http.post<Show[]>(`${this.apiUrl}/tours/${tourId}/showcollections`, showsToAdd,
      { headers: { 'Content-Type': 'application/vnd.marvin.showcollectionforcreation+json' } });
  }
}
