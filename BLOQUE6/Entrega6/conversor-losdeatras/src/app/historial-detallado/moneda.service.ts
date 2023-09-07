import { Injectable } from '@angular/core'
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';
import { IMoneda } from './IMoneda';

@Injectable({
    providedIn: 'root'
})

export class MonedaService {
  private monedaUrl = 'https://conversorwebapi.azurewebsites.net/api/monedas';

  constructor(private http: HttpClient) { }

  getMoneda(codigo:string): Observable<IMoneda> {
    let url = this.monedaUrl + "/" + codigo
    return this.http.get<IMoneda>(url).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse): Observable<never> {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}