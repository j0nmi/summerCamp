import { Component } from '@angular/core';

@Component({
  selector: 'pm-root',
  template: `
  <div>
  <pm-navbar></pm-navbar>
    <h1>{{pageTitle}}</h1>
    <h3>Moneda base del conversor: {{codigoMonedaBase}}</h3>
    <pm-welcome></pm-welcome>
    <br>
    <pm-monedas></pm-monedas>
</div>
  `

})
export class AppComponent {
  pageTitle = 'Conversor de monedas ACME v.2023';
  codigoMonedaBase = 'EUR';
  title = 'apm';
}
