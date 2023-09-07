import { Component, EventEmitter, Input, OnChanges, OnDestroy, OnInit, Output, SimpleChanges  } from '@angular/core';
import { Subscription } from 'rxjs';
import { IHistorial } from "./historial";
import { HistorialService } from './historial.service';
import { GlobalService } from '../dataGlobal/global.service';
import { Router } from '@angular/router';

@Component({
    selector: 'pm-historial',
    templateUrl: './historial.component.html'
})

export class HistorialLista implements OnInit, OnDestroy, OnChanges{
    errorMessage: string = '';
    sub!: Subscription;
    sub2!: Subscription;

    constructor(private historialLista: HistorialService, public datos:GlobalService, public router : Router) {}
    idUsuario = localStorage.getItem('idUsuario')
    pageTitle : string = 'Historial';
    @Input() historial: IHistorial[]=[];
    @Output() cambio: EventEmitter<boolean> =
    new EventEmitter<boolean>();

    onClick(): void {
      this.cambio.emit(false);
    }
    ngOnChanges(): void {
      this.actualizar()
    }
    //Cargar el historial
    ngOnInit(): void {

      }
    actualizar() {  
      this.sub = this.historialLista.getHistorial(this.idUsuario).subscribe({
        next: historial => {
          this.historial = historial;
        },
      });
     }
      ngOnDestroy(): void {
        this.sub.unsubscribe();
      }

    borrarHistorial(): void{
      const confirmacion = window.confirm('¿Estás seguro de que deseas borrar el historial?');
      if(confirmacion){
        this.sub2 = this.historialLista.borrarHistorial(this.idUsuario).subscribe()
        this.cambio.emit(true);   
    }
    }
}
