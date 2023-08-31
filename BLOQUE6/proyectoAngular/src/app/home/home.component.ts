import { Component } from '@angular/core';

@Component({
  selector: 'pm-home',
  templateUrl: './home.component.html'
})

export class HomeComponent {
  pageTitle: string = 'Conversor losdeatras';
  pageContent: string = 'Realiza tus conversiones de forma GRATUITA!! - Registrate y realiza tu primera conversión';
  imagenLogo : string = 'assets/images/Logo.png'
}
