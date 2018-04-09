import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TourDetailComponent } from './tour-detail.component';

describe('TourDetailComponent', () => {
  let component: TourDetailComponent;
  let fixture: ComponentFixture<TourDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TourDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TourDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
