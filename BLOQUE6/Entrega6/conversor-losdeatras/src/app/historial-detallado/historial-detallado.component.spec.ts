import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistorialDetalladoComponent } from './historial-detallado.component';

describe('HistorialDetalladoComponent', () => {
  let component: HistorialDetalladoComponent;
  let fixture: ComponentFixture<HistorialDetalladoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HistorialDetalladoComponent]
    });
    fixture = TestBed.createComponent(HistorialDetalladoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
