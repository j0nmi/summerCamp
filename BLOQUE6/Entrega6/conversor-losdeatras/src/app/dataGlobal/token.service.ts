import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GlobalService } from '../dataGlobal/global.service';


@Injectable()
export class AuthInterceptorService implements HttpInterceptor {

    constructor(public datos: GlobalService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = localStorage.getItem('token'); // Obtener el token de autenticación desde el almacenamiento local o las cookies
        const authRequest = request.clone({
        setHeaders: {
            Authorization: `Bearer ${token}`
        }
        });

        return next.handle(authRequest);
    }
}