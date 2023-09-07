import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BotonTopComponent } from './boton-top.component';

describe('BotonTopComponent', () => {
  let component: BotonTopComponent;
  let fixture: ComponentFixture<BotonTopComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BotonTopComponent]
    });
    fixture = TestBed.createComponent(BotonTopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
