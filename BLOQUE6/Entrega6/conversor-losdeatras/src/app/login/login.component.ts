import { Component } from '@angular/core';
import { LoginService } from './login.service';
import { NgForm } from '@angular/forms';
import { ILogin } from './Login';
import { IRespuesta } from './respuesta';
import { GlobalService } from '../dataGlobal/global.service';
import { Router } from '@angular/router';


@Component({
  selector: 'pm-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  username: string ="";
  userPassword: string ="";
  resultadoLogin: IRespuesta | undefined;
  errorMessage: string = '';
  error: boolean = false;

  constructor(public datos: GlobalService, private loginService: LoginService, public router: Router) {}

  login(f: NgForm) {
    const user : ILogin = {
      username: f.value.user,
      password: f.value.userPassword
    };
    this.loginService.getLogin(user).subscribe(
      {
      next:(login) => {
        this.resultadoLogin = login;
        var token = login.token;
        var idUsuario = login.idUsuario;
        var nombre = f.value.user;
        var expiracion = this.resultadoLogin?.expiration.toString();
        
        localStorage.setItem('token',token)
        localStorage.setItem('idUsuario', idUsuario)
        localStorage.setItem('nombre', nombre)
        localStorage.setItem('expiracion', expiracion!)
        
        if(token != null) {
          this.datos.globalData.logeado = true;
          this.error = false;
          this.router.navigate(['/inicio'])
        }
      },
      error: err  => {
        this.error = true;
      }
    });
  }
}
