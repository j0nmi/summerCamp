import { Injectable } from '@angular/core'
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { IHistorial } from './historial';
import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class HistorialService {
  historialUrl: string;
  borrarHistorialUrl: string;

  private http: HttpClient;
  
  
  constructor(httpClient: HttpClient) {
    this.historialUrl =       'https://conversorwebapi.azurewebsites.net/api/historial?usuario=';
    this.borrarHistorialUrl = 'https://conversorwebapi.azurewebsites.net/api/historial/';
    //this.historialUrl = 'https://localhost:7019/api/historial?usuario=';
    //this.borrarHistorialUrl = 'https://localhost:7019/api/historial/';
    this.http = httpClient;
    
  }
  

  getHistorial(idUsuario:string|null): Observable<IHistorial[]> {
    return this.http.get<IHistorial[]>(this.historialUrl + idUsuario).pipe(
      //tap(data => console.log('All: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }


  borrarHistorial(idUsuario:string|null): Observable<any> {
    return this.http.delete(this.borrarHistorialUrl + idUsuario);
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
