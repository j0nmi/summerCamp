import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../dataGlobal/global.service';

@Component({
  selector: 'pm-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {
  pageTitle: string = 'Conversor losdeatras';
  pageContent: string = 'Realiza tus conversiones de forma GRATUITA!! - Registrate y realiza tu primera conversión';
  imagenLogo : string = 'assets/images/Logo.png'

  constructor(public datos: GlobalService) {}
  username = localStorage.getItem('nombre')

}
