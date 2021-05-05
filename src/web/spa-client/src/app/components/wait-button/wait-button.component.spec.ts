import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WaitButtonComponent } from './wait-button.component';

describe('WaitButtonComponent', () => {
  let component: WaitButtonComponent;
  let fixture: ComponentFixture<WaitButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WaitButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WaitButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
