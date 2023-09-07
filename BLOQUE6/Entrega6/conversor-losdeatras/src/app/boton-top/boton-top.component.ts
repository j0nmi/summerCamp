import { Component, Renderer2, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'pm-boton-top',
  templateUrl: './boton-top.component.html',
  styleUrls: ['./boton-top.component.css']
})
export class BotonTopComponent {
  constructor(private renderer: Renderer2, @Inject(DOCUMENT) private document: Document) {}

  scrollToTop() {
    this.renderer.setProperty(this.document.documentElement, 'scrollTop', 0);
  }
}
