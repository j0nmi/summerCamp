import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../dataGlobal/global.service';
import { Router } from '@angular/router';

@Component({
  selector: 'pm-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class BarraNav implements OnInit{
  pageTitle: string = 'Los de Atras PROJECT';
  title : string = '';
  imagenLogo : string = 'assets/images/logoh.png'
  loginStatus= true;
  token = localStorage.getItem('token')

  constructor(public datos: GlobalService, private router : Router) {}

  isCollapse = false;   // guardamos el valor
  toggleState() { // manejador del evento
      let foo = this.isCollapse;
      this.isCollapse = foo === false ? true : false; 
  }

  logOut(){
    this.datos.globalData.logeado = false;
    localStorage.removeItem('token')
    localStorage.removeItem('idUsuario')
    localStorage.removeItem('nombre')
    this.router.navigate(['/inicio'])
  }
  
  verUsuario(){
    this.router.navigate(['/usuario'])
  }
  expiracion = localStorage.getItem('expiracion')

  ngOnInit(): void {
    // Control de expiracion de token
    const dateNow = Date.now()
    const date1 = Date.parse(this.expiracion!);
    if ((date1 - dateNow) < 0){
      localStorage.removeItem('token')
      localStorage.removeItem('idUsuario')
      localStorage.removeItem('nombre')
    }    

    if(this.token != null) {
      this.datos.globalData.logeado = true;
      this.router.navigate(['/inicio'])
    }else{
      this.datos.globalData.logeado = false;
      this.router.navigate(['/Login'])
    }
  }
        

}
