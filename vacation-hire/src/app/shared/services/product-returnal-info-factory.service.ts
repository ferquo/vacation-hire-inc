import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ProductReturnalInfo } from '../models/product-returnal-info.model';
import { HttpClient } from '@angular/common/http';
import { VechicleReturnalInfoService } from './vechicle-returnal-info.service';
import { FormBuilder, FormGroup } from '@angular/forms';

export interface IProductReturnalInfoService {
  get(id: string): Observable<ProductReturnalInfo>;
  create(returnalInfo: ProductReturnalInfo): Observable<ProductReturnalInfo>;
  buildProductReturnalForm(): FormGroup;
}

@Injectable({
  providedIn: 'root'
})
export class ProductReturnalInfoFactoryService {
  constructor(
    private http: HttpClient,
    private formBuilder: FormBuilder
  ) { }

  public createProductReturnalService(productType: string) {
    switch (productType) {
      case 'vechicle':
        return new VechicleReturnalInfoService(this.http, this.formBuilder);
      
      // Whenever there are new product types, that Vacation Hire Inc. wants to extend, will add here.
      
      default:
        throw Error('Not implemented');
    }
  }
}
