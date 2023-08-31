import { Component } from '@angular/core';

@Component({
  selector: 'pm-nav',
  templateUrl: './nav.component.html'
})

export class BarraNav {
  pageTitle: string = 'Los de Atras PROJECT';
  title : string = '';
  imagenLogo : string = 'assets/images/Logo.png'
}
