import { Component } from '@angular/core';
import { ActivatedRoute, RouterLinkActive } from '@angular/router';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IHistorial } from './IHistorial';
import { IMoneda } from './IMoneda';
import { HistorialService } from './historial.service';
import { MonedaService } from './moneda.service';


@Component({
  selector: 'pm-historial-detallado',
  templateUrl: './historial-detallado.component.html',
  styleUrls: ['./historial-detallado.component.css']
})
export class HistorialDetalladoComponent {
  constructor(private route: ActivatedRoute, private router: Router, private historialSer: HistorialService, private monedaSer:MonedaService) { }
  id: string = this.route.snapshot.paramMap.get('id')!;
  sub1!:Subscription;
  sub2!:Subscription;
  sub3!:Subscription;
  historial!:IHistorial;
  moneda1!:IMoneda;
  moneda2!:IMoneda;
  

  ngOnInit() {
    this.sub1 = this.historialSer.getHistorial(this.id).subscribe({
      next: historial => {
        this.historial = historial;
        this.sub2 = this.monedaSer.getMoneda(historial.moneda1).subscribe({
          next: moneda => {
            this.moneda1 = moneda;
          },
        });
        this.sub3 = this.monedaSer.getMoneda(historial.moneda2).subscribe({
          next: moneda => {
            this.moneda2 = moneda;
          },
        });
      },
    });
  }

  onBack(): void { 
    this.router.navigate(['/conversor']);
    }
    
}
