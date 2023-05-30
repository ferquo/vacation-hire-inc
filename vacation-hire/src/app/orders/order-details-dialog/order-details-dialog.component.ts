import { DIALOG_DATA } from '@angular/cdk/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { Order } from 'src/app/shared/models/order.model';
import { VechicleReturnalInfo } from 'src/app/shared/models/product-returnal-info.model';
import { ProductReturnalInfo } from 'src/app/shared/models/product-returnal-info.model';
import { ProductReturnalInfoFactoryService } from 'src/app/shared/services/product-returnal-info-factory.service';
import { IProductReturnalInfoService } from 'src/app/shared/services/vechicle-returnal-info.service';

@Component({
  selector: 'app-order-details-dialog',
  templateUrl: './order-details-dialog.component.html',
  styleUrls: ['./order-details-dialog.component.css']
})
export class OrderDetailsDialogComponent implements OnInit {
  
  public selectedCurrency: string = '';
  public productReturnalInfo?: ProductReturnalInfo;
  private productReturnalInfoService!: IProductReturnalInfoService;
  
  constructor(
    @Inject(DIALOG_DATA) public data: Order,
    private productReturnalInfoFactoryService: ProductReturnalInfoFactoryService) {
    this.productReturnalInfoService = this.productReturnalInfoFactoryService.createProductReturnalService(this.data.rentedProduct.productType);
  }
  
  ngOnInit(): void {
    this.selectedCurrency = this.data.productReturnalInfo?.paidInCurrency;
    this.getProductReturnalInfo();
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
