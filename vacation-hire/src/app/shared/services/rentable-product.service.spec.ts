import { TestBed } from '@angular/core/testing';

import { RentableProductService } from './rentable-product.service';

describe('RentableProductService', () => {
  let service: RentableProductService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RentableProductService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
