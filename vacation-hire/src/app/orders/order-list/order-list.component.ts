import { Dialog } from '@angular/cdk/dialog';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Order } from 'src/app/shared/models/order.model';
import { OrderService } from 'src/app/shared/services/order.service';
import { OrderDetailsDialogComponent } from '../order-details-dialog/order-details-dialog.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  displayedColumns: string[] = [
    'customerName',
    'reservedFrom',
    'reservedUntil',
    'customerPhoneNumber',
    'product',
    'status',
    'actions',
  ];
  dataSource: Array<Order> = [];
  
  totalItemCount = 0;
  pageSize = 5;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  
  constructor(
    private orderService: OrderService,
    private dialog: Dialog,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService
      .getOrders( this.pageIndex + 1, this.pageSize )
      .subscribe((data) => {
        this.dataSource = data.results;
        this.totalItemCount = data.totalItemCount;
      });
  }

  handlePageEvent(e: PageEvent) {
    this.totalItemCount = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.loadOrders();
  }

  openDialog(orderId: string) {
    this.dialog.open(OrderDetailsDialogComponent, {
      minWidth: '540px',
      data: this.dataSource.find(order => order.id === orderId),
    });
  }

  completeProductReturnal(orderId: string) {
    this.router.navigate(['/orders', orderId, 'return-product']);
  }
}
