import { Injectable, ErrorHandler } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

import { Tour } from './tour.model';
import { BaseService } from '../../shared/base.service';
import { TourWithEstimatedProfits } from './tour-with-estimated-profits.model';
import { TourForCreation } from './tour-for-creation.model';
import { TourWithManagerForCreation } from './tour-with-manager-for-creation.model';
import { TourWithShows } from './tour-with-shows.model';
import { TourWithEstimatedProfitsAndShows } from './tour-with-estimated-profits-and-shows.model';
import { TourWithShowsForCreation } from './tour-with-shows-for-creation.model';
import { TourWithManagerAndShowsForCreation } from './tour-with-manager-and-shows-for-creation.model';
import { Operation } from 'fast-json-patch';

@Injectable()
export class TourService extends BaseService {

    constructor(private http: HttpClient) {
        super();
    }

    getTours(): Observable<Tour[]> {
        return this.http.get<Tour[]>(`${this.apiUrl}/tours`);
    }

    getTour(tourId: string): Observable<Tour> {
        return this.http.get<Tour>(`${this.apiUrl}/tours/${tourId}`);
    }

    getTourWithEstimatedProfits(tourId: string): Observable<TourWithEstimatedProfits> {
        return this.http.get<TourWithEstimatedProfits>(`${this.apiUrl}/tours/${tourId}`,
            { headers: { 'Accept': 'application/vnd.marvin.tourwithestimatedprofits+json' } });
    }

    getTourWithShows(tourId: string): Observable<TourWithShows> {
        return this.http.get<TourWithShows>(`${this.apiUrl}/tours/${tourId}`,
            { headers: { 'Accept': 'application/vnd.marvin.tourwithshows+json' } });
    }

    getTourWithEstimatedProfitsAndShows(tourId: string): Observable<TourWithEstimatedProfitsAndShows> {
        return this.http.get<TourWithEstimatedProfitsAndShows>(`${this.apiUrl}/tours/${tourId}`,
            { headers: { 'Accept': 'application/vnd.marvin.tourwithestimatedprofitsandshows+json' } });
    }

    addTour(tourToAdd: TourForCreation): Observable<Tour> {
        return this.http.post<Tour>(`${this.apiUrl}/tours`, tourToAdd,
            { headers: { 'Content-Type': 'application/json' } });
    }

    addTourWithManager(tourToAdd: TourWithManagerForCreation): Observable<Tour> {
        return this.http.post<Tour>(`${this.apiUrl}/tours`, tourToAdd,
            { headers: { 'Content-Type': 'application/vnd.marvin.tourwithmanagerforcreation+json' } });
    }

    addTourWithShows(tourToAdd: TourWithShowsForCreation): Observable<Tour> {
        return this.http.post<Tour>(`${this.apiUrl}/tours`, tourToAdd,
            { headers: { 'Content-Type': 'application/vnd.marvin.tourwithshowsforcreation+json' } });
    }
    
    addTourWithManagerAndShows(tourToAdd: TourWithManagerAndShowsForCreation): Observable<Tour> {
        return this.http.post<Tour>(`${this.apiUrl}/tours`, tourToAdd,
            { headers: { 'Content-Type': 'application/vnd.marvin.tourwithmanagerandshowsforcreation+json' } });
    }

    partiallyUpdateTour(tourId: string, patchDocument: Operation[]): Observable<any> {
        return this.http.patch(`${this.apiUrl}/tours/${tourId}`, patchDocument,
        { headers: { 'Content-Type': 'application/json-patch+json' } });
        }
}
