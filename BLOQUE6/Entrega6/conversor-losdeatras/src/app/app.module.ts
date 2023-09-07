import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule  } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { MonedasLista } from './monedas/monedas-list.component';
import { HistorialLista } from './historial/historial.component';
import { BarraNav } from './barra-nav/nav.component';
import { HomeComponent } from './home/home.component';
import { Footer } from './footer/footer.component';
import { Register } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AuthInterceptorService } from './dataGlobal/token.service';
import { HistorialDetalladoComponent } from './historial-detallado/historial-detallado.component';
import { PrivacidadComponent } from './privacidad/privacidad.component';
import { BotonTopComponent } from './boton-top/boton-top.component';
// import { ConversorGuard } from './conversor/conversor.guard';
import { UsuarioGuard } from './usuario/usuario.guard';
import { HistorialGuard } from './historial-detallado/historial-detallado.guard';
import { UsuarioComponent } from './usuario/usuario.component';
import { ConversorMoneda } from './conversor/conversor.component';
import { ConversorGuard } from './conversor/conversor.guard';


const appRoutes: Routes = [
  { path: 'monedas', component: MonedasLista },
  { path: 'conversor',canActivate: [ ConversorGuard ],component: ConversorMoneda },
  { path: 'registro', component: Register },
  { path: 'Login', component: LoginComponent },
  { path: 'historial-detallado/:id', canActivate: [ HistorialGuard ], component: HistorialDetalladoComponent },
  { path: 'privacidad', component: PrivacidadComponent },
  { path: 'usuario', canActivate: [ UsuarioGuard ],component: UsuarioComponent },
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
    Register,
    LoginComponent,
    HistorialLista,
    HistorialDetalladoComponent,
    PrivacidadComponent,
    BotonTopComponent,
    UsuarioComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule 
  ],
  providers: [
    HistorialLista,
    {
      //Para que funcione las intercepciones que hacemos a la API
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
  }],
  bootstrap: [AppComponent],
})
export class AppModule {}
