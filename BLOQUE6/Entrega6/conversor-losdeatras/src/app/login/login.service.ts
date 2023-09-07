import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';

import { ILogin } from './Login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  registroUrl: string;
  private http: HttpClient;
  isLoggedIn = new BehaviorSubject(false);

  constructor(httpClient: HttpClient) {
    this.registroUrl = 'https://conversorwebapi.azurewebsites.net/api/auth/login';
    //this.registroUrl = 'https://localhost:7019/api/auth/login';
    this.http = httpClient;
  }

  
  //Realiza el POST de registro
  getLogin(login: ILogin): Observable<any> {
    return this.http.post(this.registroUrl, login);
  }
  
 
}
