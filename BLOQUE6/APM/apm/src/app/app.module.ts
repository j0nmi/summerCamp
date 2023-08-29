import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

// Al pulsar TAB agrega el IMPORT automáticamente.
import { WelcomeComponent } from 'home/welcome.component';
import { MonedasComponent } from 'monedas/monedas.component';
import { NavbarComponent } from 'navbar/navbar.component';

@NgModule({
  declarations: [AppComponent, WelcomeComponent, MonedasComponent, NavbarComponent],
  imports: [BrowserModule],
  providers: [],
  bootstrap: [AppComponent]
})


export class AppModule { }
