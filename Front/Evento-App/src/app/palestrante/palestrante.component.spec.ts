import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PalestranteComponent } from './palestrante.component';

describe('PalestranteComponent', () => {
  let component: PalestranteComponent;
  let fixture: ComponentFixture<PalestranteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PalestranteComponent]
    });
    fixture = TestBed.createComponent(PalestranteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
