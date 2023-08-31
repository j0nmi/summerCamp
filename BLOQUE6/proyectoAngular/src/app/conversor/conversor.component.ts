import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IMoneda } from '../monedas/monedas';
import { MonedasService } from '../monedas/monedas.service';
@Component({
  selector: 'pm-conversor',
  templateUrl: './conversor.component.html'
})
export class ConversorMoneda implements OnInit, OnDestroy {
  pageTitle: string = 'Conversor';
  monedas: IMoneda[] = [];
  sub!: Subscription;
  selecOrigen: string = '';
  selecDestino: string = '';
  cantidad: number = 0;
  ponerOrigen: string = '';
  ponerDestino: string = '';
  factor1: number = 0;
  factor2: number = 0;
  resultado: number = 0;
  resFormateado: string = '';

  constructor(private monedasLista: MonedasService) { }

  ngOnInit(): void {
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

  swapMonedas(): void {
    [this.selecOrigen, this.selecDestino] = [this.selecDestino, this.selecOrigen];
    this.cambiarBanderaOrigen();
    this.cambiarBanderaDestino();
  }

  cambiarBanderaOrigen(): void {
    this.ponerOrigen = `https://www.countryflagicons.com/SHINY/24/${this.selecOrigen.slice(0, 2)}.png`;

    const selectOrigen = document.getElementById('selectOrigen') as HTMLSelectElement;
    const curValue = selectOrigen.value;

    const selectDestino = document.getElementById('selectDestino') as HTMLSelectElement;
    for (let i = 0; i < selectDestino.options.length; i++) {
      const option = selectDestino.options[i];
      option.style.display = option.value === curValue ? 'none' : 'block';
    }
    selectDestino.options.selectedIndex = 0;

    this.cambiarBanderaDestino();
  }

  cambiarBanderaDestino(): void {
    this.ponerDestino = `https://www.countryflagicons.com/SHINY/24/${this.selecDestino.slice(0, 2)}.png`;
  }

  realizarConversion(): void {
    if (!this.selecOrigen || !this.selecDestino) {
      this.resFormateado = 'Seleccione las monedas de origen y destino';
      return;
    }

    if (isNaN(this.cantidad) || this.cantidad <= 0) {
      this.resFormateado = 'Ingrese una cantidad válida';
      return;
    }

    this.calcularFactores();
    this.calcularResultado();
  }


  private calcularFactores(): void {
    for (const moneda of this.monedas) {
      if (moneda.codigo === this.selecOrigen) {
        this.factor1 = moneda.factor;
      }
      if (moneda.codigo === this.selecDestino) {
        this.factor2 = moneda.factor;
      }
    }
  }

  private calcularResultado(): void {
    this.resultado = ((1 / this.factor1) * this.factor2) * this.cantidad;
    this.resFormateado = this.resultado.toFixed(4);
  }
}
