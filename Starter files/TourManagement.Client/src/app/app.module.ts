import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common'
import { HttpClient } from '@angular/common/http/src/client';

// import routing module
import { AppRoutingModule } from './app.routing';
import { AppComponent } from './app.component';
import { AboutComponent } from './about';
import {
  ToursComponent, TourAddComponent, TourDetailComponent,
  TourUpdateComponent
} from './tours';
import { ShowsComponent, ShowAddComponent } from './tours/shows';
import { TourService } from './tours/shared/tour.service'
import { ShowService } from './tours/shows/shared/show.service'
import { MasterDataService } from './shared/master-data.service';
import { GlobalErrorHandler } from './shared/global-error-handler';
import { ErrorLoggerService } from './shared/error-logger.service';
import { HandleHttpErrorInterceptor } from './shared/handle-http-error-interceptor';
import { WriteOutJsonInterceptor } from './shared/write-out-json-interceptor';

@NgModule({
  declarations: [
    AppComponent,
    AboutComponent,
    ShowsComponent,
    TourDetailComponent,
    TourAddComponent,
    ToursComponent,
    TourUpdateComponent,
    ShowAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [   
    {
      provide: HTTP_INTERCEPTORS,
      useClass: WriteOutJsonInterceptor,
      multi: true
    },    
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HandleHttpErrorInterceptor,
      multi: true,
    },
    GlobalErrorHandler, ErrorLoggerService, TourService, MasterDataService, ShowService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule {

  constructor() {

    // automapper mappings

  }
}
