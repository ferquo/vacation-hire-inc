import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Order } from 'src/app/shared/models/order.model';
import { OrderService } from 'src/app/shared/services/order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  displayedColumns: string[] = ['customerName', 'reservedFrom', 'reservedUntil', 'customerPhoneNumber'];
  dataSource: Array<Order> = [];
  
  totalItemCount = 0;
  pageSize = 5;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  
  constructor(private orderService: OrderService) { }

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
}
