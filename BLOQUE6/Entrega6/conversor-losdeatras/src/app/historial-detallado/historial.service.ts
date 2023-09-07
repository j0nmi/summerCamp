import { Injectable } from '@angular/core'
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';
import { IHistorial } from './IHistorial';


@Injectable({
    providedIn: 'root'
})

export class HistorialService {
  private historialUrl = 'https://conversorwebapi.azurewebsites.net/api/historial';

  constructor(private http: HttpClient) { }

  getHistorial(id:string): Observable<IHistorial> {
    let url = this.historialUrl + "/" + id;
    console.log(url);
    return this.http.get<IHistorial>(url).pipe(
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