import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonasModalComponent } from './personas-modal.component';

describe('PersonasModalComponent', () => {
  let component: PersonasModalComponent;
  let fixture: ComponentFixture<PersonasModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonasModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonasModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
