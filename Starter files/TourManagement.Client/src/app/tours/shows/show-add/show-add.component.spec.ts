import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAddComponent } from './show-add.component';

describe('ShowAddComponent', () => {
  let component: ShowAddComponent;
  let fixture: ComponentFixture<ShowAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShowAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
