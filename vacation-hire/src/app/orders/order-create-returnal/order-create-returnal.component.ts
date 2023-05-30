import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Order } from 'src/app/shared/models/order.model';
import { OrderService } from 'src/app/shared/services/order.service';
import { ProductReturnalInfoFactoryService } from 'src/app/shared/services/product-returnal-info-factory.service';
import { IProductReturnalInfoService } from 'src/app/shared/services/vechicle-returnal-info.service';

@Component({
  selector: 'app-order-create-returnal',
  templateUrl: './order-create-returnal.component.html',
  styleUrls: ['./order-create-returnal.component.css']
})
export class OrderCreateReturnalComponent implements OnInit, OnDestroy {

  private productReturnalInfoService!: IProductReturnalInfoService;
  createProductReturnalForm!: FormGroup;
  private routeSubscription!: Subscription;
  private orderId!: string;
  private orderDetails!: Order;
  
  constructor(
    private productReturnalInfoFactoryService: ProductReturnalInfoFactoryService,
    private orderService: OrderService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }
  
  ngOnInit() {
    this.routeSubscription = this.route.params.subscribe(params => {
      this.orderId = params['id'];

      this.orderService.getOrder(this.orderId).subscribe((order) => {
        this.orderDetails = order;
        this.productReturnalInfoService = this.productReturnalInfoFactoryService
          .createProductReturnalService(this.orderDetails.rentedProduct.productType);
      });
    });  
  }
  
  ngOnDestroy(): void {
    this.routeSubscription.unsubscribe();
  }
}
