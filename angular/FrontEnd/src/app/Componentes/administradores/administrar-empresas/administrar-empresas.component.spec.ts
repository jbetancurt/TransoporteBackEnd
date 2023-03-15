import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministrarEmpresasComponent } from './administrar-empresas.component';

describe('AdministrarEmpresasComponent', () => {
  let component: AdministrarEmpresasComponent;
  let fixture: ComponentFixture<AdministrarEmpresasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdministrarEmpresasComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdministrarEmpresasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
