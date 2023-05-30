import { TestBed } from '@angular/core/testing';

import { ProductReturnalInfoFactoryService } from './product-returnal-info-factory.service';

describe('ProductReturnalInfoFactoryService', () => {
  let service: ProductReturnalInfoFactoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductReturnalInfoFactoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
