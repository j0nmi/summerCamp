import { Component } from "@angular/core";

@Component({
  selector: 'pm-monedas',
  template: `
    <div>
      <h3>Lista de Monedas</h3>
      <ul>
        <li>Dólar estadounidense (USD)</li>
        <li>Euro (EUR)</li>
        <li>Libra esterlina (GBP)</li>
        <li>Yen japonés (JPY)</li>
        <li>Dólar australiano (AUD)</li>
      </ul>
    </div>
  `
})

export class MonedasComponent {
}
