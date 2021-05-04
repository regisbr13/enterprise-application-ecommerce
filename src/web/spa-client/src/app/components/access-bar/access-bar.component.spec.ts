import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessBarComponent } from './access-bar.component';

describe('AccessBarComponent', () => {
  let component: AccessBarComponent;
  let fixture: ComponentFixture<AccessBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccessBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccessBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
