import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IMoneda } from "./monedas";
import { MonedasService } from './monedas.service';

@Component({
    selector: 'pm-monedas',
    templateUrl: './listamonedas.component.html'
})

export class MonedasLista implements OnInit, OnDestroy{
    monedas: IMoneda[] = [];
    filteredMonedas: IMoneda[] = [];
    errorMessage: string = '';
    sub!: Subscription;
    pageTitle : string = 'Lista Monedas';
    private _listFilter: string = '';

    constructor(private monedasLista: MonedasService) {}

    //Filtro para los paises por Codigo
    get listFilter(): string {
      return this._listFilter;
    }
    set listFilter(value: string) {
      this._listFilter = value;
      this.filteredMonedas = this.performFilter(value);
    }

    performFilter(filterBy: string): IMoneda[] {
      filterBy = filterBy.toLocaleUpperCase();
      return this.monedas.filter((m: IMoneda) =>
      m.codigo.toLocaleUpperCase().includes(filterBy));
    }

    //Cargar las monedas
      ngOnInit(): void {
        this.sub = this.monedasLista.getMonedas().subscribe({
          next: monedas => {
            this.monedas = monedas;
            this.filteredMonedas = this.monedas.sort((a: any, b: any) => {
              if (a.codigo.toLocaleUpperCase() < b.codigo.toLocaleUpperCase()) {
                return -1;
              } else if (a.codigo > b.codigo) {
                return 1;
              } else {
                return 0;
              }
            });
          },
        });
      }

      ngOnDestroy(): void {
        this.sub.unsubscribe();
      }
}
