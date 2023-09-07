import { NgModule, Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { IMoneda } from "../monedas/monedas";
import { IHistorial } from "../historial/historial";
import { IRespuestaConversor } from "../conversor/respuesta";
import { MonedasService } from '../monedas/monedas.service';
import { ConversorDTO } from './conversor';
import { ConversorService } from './conversor.service';
import { GlobalService } from '../dataGlobal/global.service';
import { Router } from '@angular/router';
import { HistorialLista } from '../historial/historial.component';
import { HistorialService } from '../historial/historial.service';
import { FormControl, Validators } from '@angular/forms';


@Component({
    selector: 'pm-conversor',
    templateUrl: './conversor.component.html',
})

export class ConversorMoneda implements OnInit, OnDestroy{
  pageTitle : string = 'Conversor';
  monedas: IMoneda[] = [];
  sub!: Subscription;
  selecOrigen: string="";
  selecDestino:string="";
  importe:number=0;
  resultado:number=0;
  ponerOrigen:string="";
  ponerDestino:string="";
  resFormateado:number | undefined;
  resultConversion: IRespuestaConversor | undefined;
  hayCambiosAqui : boolean = false;
  historial: IHistorial[] = [];
  mensaje: string = "";
  pattern :string ="^(3\d{11})\R+([\s\S]*?)(?=\R3\d{11}|\z)"


  constructor(private monedasLista: MonedasService,
     private conversorService: ConversorService,
     public datos: GlobalService,
     private router: Router,
     public historialLista: HistorialService) {}
  
  ngOnInit(): void {
    this.cargarLista(true)
    this.sub = this.monedasLista.getMonedas().subscribe({
      next: (monedas: IMoneda[]) => {
        this.monedas = monedas.sort((a: IMoneda, b: IMoneda) =>
          a.codigo.toLocaleUpperCase().localeCompare(b.codigo.toLocaleUpperCase())
        );
      }
    });
  }
  

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  swapMonedas(): void{
    [this.selecOrigen, this.selecDestino] = [this.selecDestino, this.selecOrigen]
    this.cambiarBanderaOrigen();
    this.cambiarBanderaDestino();
  };

  cambiarBanderaOrigen(): void {
    this.ponerOrigen = `https://www.countryflagicons.com/SHINY/24/${this.selecOrigen.slice(0, 2)}.png`;

    var selectOrigen = document.getElementById('selectOrigen') as HTMLSelectElement;
    var curValue = selectOrigen.value;

    var selectDestino = document.getElementById('selectDestino') as HTMLSelectElement;
    for (let i = 0; i < selectDestino.options.length; i++) {
      var option = selectDestino.options[i];
      option.style.display = option.value === curValue ? 'none' : 'block';
    }
    selectDestino.options.selectedIndex = 0;
  }

  cambiarBanderaDestino(): void {
    this.ponerDestino = `https://www.countryflagicons.com/SHINY/24/${this.selecDestino.slice(0, 2)}.png`;
  }

  idUsuario = localStorage.getItem('idUsuario')

  convertirMoneda(): void {
    //Comprobrar Monedas Seleccionadas
    if (!this.selecOrigen || !this.selecDestino) {
      this.mensaje = 'Seleccione las monedas de origen y destino';
    }
    //Comprobar importe
    else if (isNaN(this.importe) || this.importe <= 0) {
      this.mensaje = 'Ingrese una cantidad válida';
    }else{
      const conversorDTO: ConversorDTO = {
        monedaOrigen: this.selecOrigen,
        monedaDestino: this.selecDestino,
        cantidad: this.importe
      };
      this.postConversor(conversorDTO,this.idUsuario);
    }
  }

  cargarLista(cambio : boolean): void {
    this.sub = this.historialLista.getHistorial(this.idUsuario).subscribe({
      next: historial => {
        this.historial = historial;
      },
    });
  }

  postConversor(conversorDTO: ConversorDTO, idUsuario: string|null): void {
    this.conversorService.postRealizarConversion(conversorDTO, idUsuario).subscribe({
      next:(conversion) => {
        this.resultConversion = conversion;
        this.resFormateado = this.resultConversion?.resultadoConversion
        this.cargarLista(true)
        this.mensaje = ""
      }
    });
  }

}
