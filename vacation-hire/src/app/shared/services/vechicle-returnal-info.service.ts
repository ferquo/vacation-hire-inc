import { Injectable } from '@angular/core';
import { ProductReturnalInfo, VechicleReturnalInfo } from '../models/product-returnal-info.model';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError, retry, throwError } from 'rxjs';
import { IProductReturnalInfoService } from './product-returnal-info-factory.service';
import { FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class VechicleReturnalInfoService implements IProductReturnalInfoService {

  apiURL = environment.apiUrl + '/api';
  constructor(
    private http: HttpClient,
    private formBuilder: FormBuilder,
  ) { }
  
  get(id: string): Observable<VechicleReturnalInfo> {
    return this.http
      .get<VechicleReturnalInfo>(this.apiURL + '/orders/product-returnals/vechicle-returnals/' + id)
      .pipe(retry(1), catchError(this.handleError));
  }

  create(returnalInfo: VechicleReturnalInfo): Observable<VechicleReturnalInfo> {
    return this.http
      .post<VechicleReturnalInfo>(
        this.apiURL + '/orders',
        JSON.stringify(returnalInfo)
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  buildProductReturnalForm() {
    return this.formBuilder.group({
      customerName: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      reservedFrom: [null, Validators.required],
      reservedUntil: [null, Validators.required],
      customerPhoneNumber: [null, Validators.compose([Validators.required, Validators.pattern(`^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$`)])],
      rentedProductId: [null, Validators.required],
    });
  }

  // Error handling
  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Message: ${error.error.error}`;
    }
    window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}
export { IProductReturnalInfoService };

