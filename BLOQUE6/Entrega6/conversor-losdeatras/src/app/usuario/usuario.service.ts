import { Injectable } from '@angular/core'
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { IUsuario } from './usuario';
import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class UsuarioService {
  private usuarioUrl = 'https://conversorwebapi.azurewebsites.net/api/usuarios/';
  idUsuario = localStorage.getItem('idUsuario')

  constructor(private http: HttpClient) { }

  getUsuario(): Observable<IUsuario> {
    return this.http.get<IUsuario>(this.usuarioUrl + this.idUsuario).pipe(
      tap(data => console.log('All: ', JSON.stringify(data))),
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
