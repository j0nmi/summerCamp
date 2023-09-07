import { ConversorDTO } from './conversor';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConversorService {
  conversorUrl: string;

  private http: HttpClient;

  constructor(httpClient: HttpClient) {
    //this.conversorUrl = 'https://localhost:7019/api/conversor?usuario=';
    this.conversorUrl = 'https://conversorwebapi.azurewebsites.net/api/conversor?usuario=';
    this.http = httpClient;
  }

  postRealizarConversion(conversor: ConversorDTO, idUsuario:string|null): Observable<any> {
    return this.http.post(this.conversorUrl + idUsuario, conversor);
  }
}
