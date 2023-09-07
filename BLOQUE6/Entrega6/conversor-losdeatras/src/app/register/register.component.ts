import { Component, OnDestroy, OnInit } from '@angular/core';
import { PaisService } from './pais.service';
import { IPais } from './pais';
import { Subscription } from 'rxjs';
import { RegistroService } from './registro.service';
import { IRegistro } from './registro';
import { Validators, FormBuilder, FormGroup} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'pm-register',
  templateUrl: './register.component.html',
})

export class Register implements OnInit, OnDestroy{
  imagenLogo : string = 'assets/images/Logo.png'
  paises: IPais[] = [];
  filteredPaises: IPais[] = [];
  errorMessage: string = '';
  sub!: Subscription;
  resultRegistro: string="";

  //Para Rellenar
  pais: string="";
  nacimiento: string ="";
  user: string ="";
  userEmail: string ="";
  userPassword: string ="";
  myForm: FormGroup;


  constructor(private paisesLista: PaisService, private registroService: RegistroService, public fb: FormBuilder, public router: Router) {
    this.myForm = this.fb.group({
      pais: ['', [Validators.required]],
      nacimiento: ['', [Validators.required, Validators.max(new Date(new Date().getFullYear() - 16).getTime()), Validators.min(new Date(new Date().getFullYear() - 150).getTime())]],
      userEmail: ['', [Validators.required, Validators.pattern('^(?:(?!.*?[.]{2})[a-zA-Z0-9](?:[a-zA-Z0-9.+!%-]{1,64}|)|\"[a-zA-Z0-9.+!% -]{1,64}\")@[a-zA-Z0-9][a-zA-Z0-9.-]+(.[a-z]{2,}|.[0-9]{1,})$')]],
      user: ['', [Validators.required, Validators.minLength(5)]],
      userPassword: ['', [Validators.required, Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{6,}')]],
      
    });
  }
  ngOnInit(): void {
    this.sub = this.paisesLista.getPaises().subscribe({
      next: paises => {
        this.paises = paises;
        this.filteredPaises = this.paises.sort((a: any, b: any) => {
          if (a.nombre.toLocaleUpperCase() < b.nombre.toLocaleUpperCase()) {
            return -1;
          } else if (a.nombre > b.nombre) {
            return 1;
          } else {
            return 0;
          }
        });
      },
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  //Rellena con los datos del html un registro DTO
  rellenarRegistro(myForm : FormGroup): void {
    const registroDTO: IRegistro = {
      idPais: myForm.value.pais,
      fechaNacimiento: myForm.value.nacimiento,
      username: myForm.value.user,
      email: myForm.value.userEmail,
      password: myForm.value.userPassword
    };
    this.postRegistro(registroDTO);
    this.router.navigate(['/inicio'])
  }

  //Realiza el POST enviando el registro rellenado
  postRegistro(registroDTO: IRegistro): void {
  this.registroService.postRealizarRegistro(registroDTO).subscribe({
    next:(registro) => {
      this.resultRegistro = registro;
    }
  });
}
}