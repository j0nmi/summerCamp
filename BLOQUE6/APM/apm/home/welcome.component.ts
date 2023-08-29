import { Component } from "@angular/core";

@Component({
    selector: 'pm-welcome',
    template: '<div>{{saludo}}</div>'
})
export class WelcomeComponent{
saludo: string = 'Hola mundo! Esta es mi primera página con Angular.';
}