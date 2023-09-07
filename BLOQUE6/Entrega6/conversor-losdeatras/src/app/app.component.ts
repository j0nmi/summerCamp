import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'pm-root',
  templateUrl: './app.component.html'
})

export class AppComponent implements OnInit {
  pageTitle: string = 'Los de Atras PROJECT';
  title : string = '';

  name = 'Angular';
   
  ngOnInit(){
     window.addEventListener("keyup", disableF5);
     window.addEventListener("keydown", disableF5);
   
    function disableF5(e :any) {
       if ((e.which || e.keyCode) == 116) e.preventDefault(); 
    };
  }
}
