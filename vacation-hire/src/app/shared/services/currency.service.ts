import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Currency } from '../models/currency.model';
import { catchError, retry, take } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {

  apiURL = environment.apiUrl + '/api';
  constructor(private http: HttpClient) { }

  getAllCurrencies(): Observable<Array<Currency>> {
    return this.http
      .get<Array<Currency>>(this.apiURL + '/currencies')
      .pipe(take(1), retry(1), catchError(this.handleError));
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
