import { ProductTypeEnum } from "./product-type.model";

export interface RentableProduct {
    id: string;
    name: string;
    productType: ProductTypeEnum;
}
