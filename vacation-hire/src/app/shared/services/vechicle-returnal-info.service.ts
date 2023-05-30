import { Injectable } from '@angular/core';
import { ProductReturnalInfo, VechicleReturnalInfo } from '../models/product-returnal-info.model';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError, retry, throwError } from 'rxjs';
import { IProductReturnalInfoService } from './product-returnal-info-factory.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class VechicleReturnalInfoService implements IProductReturnalInfoService {

  apiURL = environment.apiUrl + '/api';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

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
        this.apiURL + '/orders/product-returnals/vechicle-returnals/',
        JSON.stringify(returnalInfo),
        this.httpOptions
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  buildProductReturnalForm(): FormGroup {
    return this.formBuilder.group({
      paidAmount: [null, [Validators.required, Validators.min(0)]],
      paidInCurrency: [null, Validators.required],
      fuelPercentage: [null, Validators.compose([Validators.required, Validators.min(0), Validators.max(1)])],
      vechicleDamageNotes: [null],
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

