import { TestBed, inject } from '@angular/core/testing';

import { MasterDataService } from './master-data.service';

describe('MasterDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MasterDataService]
    });
  });

  it('should be created', inject([MasterDataService], (service: MasterDataService) => {
    expect(service).toBeTruthy();
  }));
});
