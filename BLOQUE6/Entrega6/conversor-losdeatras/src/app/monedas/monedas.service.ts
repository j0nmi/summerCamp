import { Injectable } from '@angular/core'
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { IMoneda } from './monedas';
import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class MonedasService {
  //private monedaUrl = 'api/monedas.json';
  private monedaUrl = 'https://conversorwebapi.azurewebsites.net/api/monedas';

  constructor(private http: HttpClient) { }

  getMonedas(): Observable<IMoneda[]> {
    return this.http.get<IMoneda[]>(this.monedaUrl).pipe(
      //tap(data => console.log('All: ', JSON.stringify(data))),
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

