import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { throwError } from 'rxjs/internal/observable/throwError';
import { catchError, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { RentableProduct } from '../models/rentable-product.model';

@Injectable({
  providedIn: 'root'
})
export class RentableProductService {
  // Define API
  apiURL = environment.apiUrl + '/api';
  constructor(private http: HttpClient) { }

  getRentableProducts(): Observable<Array<RentableProduct>> {
    return this.http
      .get<Array<RentableProduct>>( this.apiURL + '/rentable-products' )
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
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}
