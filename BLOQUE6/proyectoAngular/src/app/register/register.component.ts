import { Component, OnDestroy, OnInit } from '@angular/core';
import { PaisService } from './pais.service';
import { IPais } from './pais';
import { Subscription } from 'rxjs';

@Component({
  selector: 'pm-register',
  templateUrl: './register.component.html'
})

export class Register implements OnInit, OnDestroy{
  imagenLogo : string = 'assets/images/Logo.png'
  paises: IPais[] = [];
  paisSelec: IPais[] = [];
  filteredPaises: IPais[] = [];
  errorMessage: string = '';
  sub!: Subscription;
  constructor(private paisesLista: PaisService) {}

  ngOnInit(): void {
    this.sub = this.paisesLista.getMonedas().subscribe({
      next: paises => {
        this.paises = paises;
        this.filteredPaises = this.paises.sort((a: any, b: any) => {
          if (a.nombre.toLocaleUpperCase() < b.nombre.toLocaleUpperCase()) {
            return -1;
          } else if (a.nombre > b.nombre) {
            return 1;
          } else {
            return 0;
          }
        });
      },
    });
    console.log(this.paises);
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  
}