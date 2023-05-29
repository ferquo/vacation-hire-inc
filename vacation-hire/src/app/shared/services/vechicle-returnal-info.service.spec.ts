import { TestBed } from '@angular/core/testing';

import { VechicleReturnalInfoService } from './vechicle-returnal-info.service';

describe('VechicleReturnalInfoService', () => {
  let service: VechicleReturnalInfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VechicleReturnalInfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
