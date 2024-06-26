import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalaryViewComponentComponent } from './salary-view-component.component';

describe('SalaryViewComponentComponent', () => {
  let component: SalaryViewComponentComponent;
  let fixture: ComponentFixture<SalaryViewComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SalaryViewComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SalaryViewComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
