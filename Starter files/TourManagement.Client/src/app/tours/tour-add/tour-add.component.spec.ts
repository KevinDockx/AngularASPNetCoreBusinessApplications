import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TourAddComponent } from './tour-add.component';

describe('TourAddComponent', () => {
  let component: TourAddComponent;
  let fixture: ComponentFixture<TourAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TourAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TourAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
