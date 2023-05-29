import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { throwError } from 'rxjs/internal/observable/throwError';
import { catchError, retry } from 'rxjs/operators';
import { Order } from '../models/order.model';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../models/paginated-result.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  apiURL = environment.apiUrl + '/api';
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getOrders(pageNumber: number = 1, pageSize: number = 5): Observable<PaginatedResult<Order>> {
    let params = new HttpParams();
    params = params.append('page', pageNumber);
    params = params.append('pageSize', pageSize);

    return this.http
      .get<PaginatedResult<Order>>(
        this.apiURL + '/orders', { params }
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  getOrder(id: any): Observable<Order> {
    return this.http
      .get<Order>(this.apiURL + '/orders/' + id)
      .pipe(retry(1), catchError(this.handleError));
  }

  createOrder(order: Order): Observable<Order> {
    return this.http
      .post<Order>(
        this.apiURL + '/orders',
        JSON.stringify(order),
        this.httpOptions
      )
      .pipe(retry(1), catchError(this.handleError));
  }
  
  updateOrder(id: any, order: any): Observable<Order> {
    return this.http
      .put<Order>(
        this.apiURL + '/orders/' + id,
        JSON.stringify(order),
        this.httpOptions
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  deleteEmployee(id: any) {
    return this.http
      .delete<Order>(this.apiURL + '/orders/' + id, this.httpOptions)
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
