import { TestBed, inject } from '@angular/core/testing';

import { RequireAuthenticatedUserRouteGuardService } from './require-authenticated-user-route-guard.service';

describe('RequireAuthenticatedUserRouteGuardService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RequireAuthenticatedUserRouteGuardService]
    });
  });

  it('should be created', inject([RequireAuthenticatedUserRouteGuardService], (service: RequireAuthenticatedUserRouteGuardService) => {
    expect(service).toBeTruthy();
  }));
});
