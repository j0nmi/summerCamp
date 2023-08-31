import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { MonedasLista } from './monedas/monedas-list.component';
import { ConversorMoneda } from './conversor/conversor.component';
import { BarraNav } from './barra-nav/nav.component';
import { HomeComponent } from './home/home.component';
import { Footer } from './footer/footer.component';
import { Register } from './register/register.component';

const appRoutes: Routes = [
  { path: 'monedas', component: MonedasLista },
  { path: 'conversor', component: ConversorMoneda },
  { path: 'registro', component: Register },
  { path: 'inicio', component: HomeComponent },
  { path: '', redirectTo: 'inicio', pathMatch: 'full' },
  { path: '**', redirectTo: 'inicio', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    MonedasLista,
    ConversorMoneda,
    HomeComponent,
    BarraNav,
    Footer,
    Register
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
