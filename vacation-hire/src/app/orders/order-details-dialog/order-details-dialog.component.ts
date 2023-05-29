import { DIALOG_DATA } from '@angular/cdk/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { Order } from 'src/app/shared/models/order.model';
import { VechicleReturnalInfo } from 'src/app/shared/models/product-returnal-info.model';
import { ProductReturnalInfo } from 'src/app/shared/models/product-returnal-info.model';

@Component({
  selector: 'app-order-details-dialog',
  templateUrl: './order-details-dialog.component.html',
  styleUrls: ['./order-details-dialog.component.css']
})
export class OrderDetailsDialogComponent implements OnInit {
  
  public selectedCurrency: string = '';
  public productReturnalInfo?: ProductReturnalInfo | VechicleReturnalInfo;
  
  constructor(@Inject(DIALOG_DATA) public data: Order) { }
  
  ngOnInit(): void {
    this.selectedCurrency = this.data.productReturnalInfo?.paidInCurrency;
    this.productReturnalInfo = this.data.productReturnalInfo;
  }
  
  buildProductReturnalInfo() {
    if (this.data.rentedProduct.productType === 'vechicle') {
      this.productReturnalInfo = this.data.productReturnalInfo as VechicleReturnalInfo;
    }
    this.productReturnalInfo = this.data.productReturnalInfo;
  }

  get getFuelPercentage(): number | undefined {
    return (this.productReturnalInfo as VechicleReturnalInfo)?.fuelPercentage;
  };
}
