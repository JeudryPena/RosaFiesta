import { AddressResponse } from "../../../security/response/addressResponse";
import { PurchaseDetailResponse } from "./purchaseDetailResponse";

export interface OrderResponse {
    sKU: number;
    payMethodId: string;
    userId: string;
    orderDate: string;
    shippingCost: number;
    voucherType: string;
    voucherNumber: number;
    voucherSeries: string;
    ammountPaid: number;
    taxesCost: number;
    details: PurchaseDetailResponse[];
    addressId: string;
    address: AddressResponse;
}