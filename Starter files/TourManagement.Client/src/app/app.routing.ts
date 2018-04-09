import { Routes, RouterModule } from '@angular/router';

import { AboutComponent } from './about'; 
import { AppComponent } from './app.component';
import { ToursComponent, TourDetailComponent, TourUpdateComponent, TourAddComponent } from './tours';

import { NgModule } from '@angular/core';
import { ShowAddComponent } from './tours/shows/index';

const routes: Routes = [
    // redirect root to the dasbhoard route
    { path: '', redirectTo: 'tours', pathMatch: 'full' },
    { path: 'tours', component: ToursComponent },
    { path: 'about', component: AboutComponent },
    { path: 'tours/:tourId', component: TourDetailComponent },
    { path: 'tour-update/:tourId', component: TourUpdateComponent },  
    { path: 'tour-add', component: TourAddComponent },  
    { path: 'tours/:tourId/show-add', component: ShowAddComponent }
  //  { path: '**', redirectTo: 'tours' },
];

// define a module
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
