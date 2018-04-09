import { TestBed, inject } from '@angular/core/testing';

import { OpenIdConnectService } from './open-id-connect.service';

describe('OpenIdConnectService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OpenIdConnectService]
    });
  });

  it('should be created', inject([OpenIdConnectService], (service: OpenIdConnectService) => {
    expect(service).toBeTruthy();
  }));
});
