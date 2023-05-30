import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderCreateReturnalComponent } from './order-create-returnal.component';

describe('OrderCreateReturnalComponent', () => {
  let component: OrderCreateReturnalComponent;
  let fixture: ComponentFixture<OrderCreateReturnalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrderCreateReturnalComponent]
    });
    fixture = TestBed.createComponent(OrderCreateReturnalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
