import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatLayout } from './seat-layout';

describe('SeatLayout', () => {
  let component: SeatLayout;
  let fixture: ComponentFixture<SeatLayout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SeatLayout],
    }).compileComponents();

    fixture = TestBed.createComponent(SeatLayout);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
