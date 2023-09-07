import { IRegistro } from './registro';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistroService {
  registroUrl: string;
  private http: HttpClient;

  constructor(httpClient: HttpClient) {
    this.registroUrl = 'https://conversorwebapi.azurewebsites.net/api/auth/register';
    this.http = httpClient;
  }

  //Realiza el POST de registro
  postRealizarRegistro(registro: IRegistro): Observable<any> {
    return this.http.post(this.registroUrl, registro);
  }
}
