import { Injectable } from '@angular/core'
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';
import { IPais } from './pais';

@Injectable({ 
    providedIn: 'root'
})

export class PaisService {
  //private paisUrl = 'https://localhost:7019/api/paises';
  private paisUrl = 'https://conversorwebapi.azurewebsites.net/api/paises';
  
  constructor(private http: HttpClient) { } 

  getPaises(): Observable<IPais[]> {
    return this.http.get<IPais[]>(this.paisUrl).pipe(
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

