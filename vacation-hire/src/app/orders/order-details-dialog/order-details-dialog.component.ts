import { DIALOG_DATA } from '@angular/cdk/dialog';
import { Component, Inject, OnInit, inject } from '@angular/core';
import { throwError } from 'rxjs';
import { Order } from 'src/app/shared/models/order.model';
import { VechicleReturnalInfo } from 'src/app/shared/models/product-returnal-info.model';
import { ProductReturnalInfo } from 'src/app/shared/models/product-returnal-info.model';
import { IProductReturnalInfoService, VechicleReturnalInfoService } from 'src/app/shared/services/vechicle-returnal-info.service';

@Component({
  selector: 'app-order-details-dialog',
  templateUrl: './order-details-dialog.component.html',
  styleUrls: ['./order-details-dialog.component.css']
})
export class OrderDetailsDialogComponent implements OnInit {
  
  public selectedCurrency: string = '';
  public productReturnalInfo?: ProductReturnalInfo;
  private productReturnalInfoService!: IProductReturnalInfoService;
  
  constructor(@Inject(DIALOG_DATA) public data: Order) {
    this.buildProductReturnalInfoService();
  }
  
  ngOnInit(): void {
    this.selectedCurrency = this.data.productReturnalInfo?.paidInCurrency;
    this.getProductReturnalInfo();
  }
  
  buildProductReturnalInfoService() {
    if (this.data.rentedProduct.productType === 'vechicle') {
      this.productReturnalInfoService = inject(VechicleReturnalInfoService);
      this.productReturnalInfo = this.data.productReturnalInfo as VechicleReturnalInfo;
    }
    this.productReturnalInfo = this.data.productReturnalInfo;
  }
  
  getProductReturnalInfo() {
    if (this.data.productReturnalInfo?.id) {
      this.productReturnalInfoService.get(this.data.productReturnalInfo?.id).subscribe((data) => {
        this.productReturnalInfo = data;
      });
    }
  }

  get getFuelPercentage(): number | undefined {
    return (this.productReturnalInfo as VechicleReturnalInfo)?.fuelPercentage;
  };

  get getVechicleDamageNotes(): string | undefined {
    return (this.productReturnalInfo as VechicleReturnalInfo)?.vechicleDamageNotes;
  };
}
