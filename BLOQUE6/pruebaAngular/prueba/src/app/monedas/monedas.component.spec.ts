import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonedasComponent } from './monedas.component';

describe('MonedasComponent', () => {
  let component: MonedasComponent;
  let fixture: ComponentFixture<MonedasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MonedasComponent]
    });
    fixture = TestBed.createComponent(MonedasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
