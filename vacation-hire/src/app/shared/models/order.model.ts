import { ProductReturnalInfo } from "./product-returnal-info.model";
import { RentableProduct } from "./rentable-product.model";

export interface Order {
    id: string;
    customerName: string;
    customerPhoneNumber: string;
    reservedFrom: Date;
    reservedUntil: Date;
    rentedProduct: RentableProduct;
    productReturnalInfo: ProductReturnalInfo;
}
