import { Component } from '@angular/core';

@Component({
  selector: 'pm-root',
  template: `
  <div>
    <h1>{{pageTitle}}</h1>
    <h3>Moneda base del conversor: {{codigoMonedaBase}}</h3>
    <div>Este es mi primer componente en Angular.JS</div>
</div>
  `

})
export class AppComponent {
  pageTitle = 'Conversor de monedas ACME v.2023';
  codigoMonedaBase = 'EUR';
}
