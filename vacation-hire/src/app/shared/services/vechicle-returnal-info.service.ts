import { Injectable } from '@angular/core';
import { ProductReturnalInfo, VechicleReturnalInfo } from '../models/product-returnal-info.model';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError, retry, throwError } from 'rxjs';

export interface IProductReturnalInfoService {
  get(id: string): Observable<ProductReturnalInfo>;
  create(returnalInfo: ProductReturnalInfo): Observable<ProductReturnalInfo>;
}

@Injectable({
  providedIn: 'root'
})
export class VechicleReturnalInfoService implements IProductReturnalInfoService {

  apiURL = environment.apiUrl + '/api';
  constructor(private http: HttpClient) { }
  
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
