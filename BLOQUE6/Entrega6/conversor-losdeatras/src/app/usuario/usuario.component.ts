import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IUsuario } from "./usuario";
import { UsuarioService } from './usuario.service';

@Component({
  selector: 'pm-usuario',
  templateUrl: './usuario.component.html',
})
export class UsuarioComponent implements OnInit, OnDestroy{
  sub!: Subscription;
  pageTitle : string = 'Usuario';
  nombreUsuario = localStorage.getItem('nombre')

  constructor(private usuarioLista: UsuarioService) {}

  usuario!: IUsuario;
  //Cargar el usuario
    ngOnInit(): void {
      this.sub = this.usuarioLista.getUsuario().subscribe({
        next: usuario => {
          this.usuario = usuario;
          console.log(this.usuario)
        },
      });
      
    }

    ngOnDestroy(): void {
      this.sub.unsubscribe();
    }
}