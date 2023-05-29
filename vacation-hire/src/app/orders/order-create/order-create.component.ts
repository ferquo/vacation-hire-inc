import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Order } from 'src/app/shared/models/order.model';
import { RentableProduct } from 'src/app/shared/models/rentable-product.model';
import { OrderService } from 'src/app/shared/services/order.service';
import { RentableProductService } from 'src/app/shared/services/rentable-product.service';

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.css']
})
export class OrderCreateComponent implements OnInit {
  createOrderForm!: FormGroup;
  products: Array<RentableProduct> = [];

  constructor(
    private formBuilder: FormBuilder,
    private rentableProductService: RentableProductService,
    private orderService: OrderService,
    private router: Router,
  ) { }

  ngOnInit() {
    this.initializeForm();
    this.initializeProductsArray();
  }

  private initializeForm() {
    this.createOrderForm = this.formBuilder.group({
      customerName: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      reservedFrom: [null, Validators.required],
      reservedUntil: [null, Validators.required],
      customerPhoneNumber: [null, Validators.required],
      rentedProductId: [null, Validators.required],
    });
  }

  private initializeProductsArray() {
    this.rentableProductService.getRentableProducts().subscribe((products) => {
      this.products = products;
    });
  }

  submit() {
    if (!this.createOrderForm.valid) {
      return;
    }
    
    this.orderService.createOrder(this.createOrderForm.value as Order).subscribe((_data: {}) => {
      this.router.navigate(['/orders']);
    });
  }
}
