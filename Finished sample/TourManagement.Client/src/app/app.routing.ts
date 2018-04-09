import { Routes, RouterModule } from '@angular/router';

import { AboutComponent } from './about'; 
import { AppComponent } from './app.component';
import { ToursComponent, TourDetailComponent, TourUpdateComponent, TourAddComponent } from './tours';

import { NgModule } from '@angular/core';
import { ShowAddComponent } from './tours/shows/index';
import { SigninOidcComponent } from './signin-oidc/signin-oidc.component';

import { RequireAuthenticatedUserRouteGuardService } 
from './shared/require-authenticated-user-route-guard.service';
import { RedirectSilentRenewComponent } from './redirect-silent-renew/redirect-silent-renew.component';

const routes: Routes = [
    { path: '', redirectTo: 'tours', pathMatch: 'full', 
    canActivate: [RequireAuthenticatedUserRouteGuardService] },
    { path: 'tours', component: ToursComponent, 
    canActivate: [RequireAuthenticatedUserRouteGuardService] },
    { path: 'about', component: AboutComponent },
    { path: 'tours/:tourId', component: TourDetailComponent, 
    canActivate: [RequireAuthenticatedUserRouteGuardService] },
    { path: 'tour-update/:tourId', component: TourUpdateComponent,
    canActivate: [RequireAuthenticatedUserRouteGuardService] }, 
    { path: 'tour-add', component: TourAddComponent,
    canActivate: [RequireAuthenticatedUserRouteGuardService] }, 
    { path: 'tours/:tourId/show-add', component: ShowAddComponent,
    canActivate: [RequireAuthenticatedUserRouteGuardService] },
    { path: 'signin-oidc', component: SigninOidcComponent },
    { path: 'redirect-silentrenew', component: RedirectSilentRenewComponent }
    ];

// define a module
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
