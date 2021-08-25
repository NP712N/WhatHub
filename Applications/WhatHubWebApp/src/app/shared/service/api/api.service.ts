import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  readonly _http: HttpClient;
  readonly _baseURL = 'https://localhost:44339/api/';
  constructor(private readonly http: HttpClient) {
    this._http = http;
  }

  get(url: string, httpOptions?: any): Observable<any> {
    return this._http.get(this._baseURL + url).pipe(catchError(this._handleError));
  }

  private _handleError(error: HttpErrorResponse) {
    return throwError(error);
  }
}
