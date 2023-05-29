import { TestBed } from '@angular/core/testing';

import { ProductReturnalInfoService } from './product-returnal-info.service';

describe('ProductReturnalInfoService', () => {
  let service: ProductReturnalInfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductReturnalInfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
