export interface ProductReturnalInfo {
    id: string;
    paidAmount: number;
    paidInCurrency: string;
    orderId: string;
}

export interface VechicleReturnalInfo extends ProductReturnalInfo {
    fuelPercentage: number;
    vechicleDamageNotes: string;
}
