import { AddressResponse } from "../../../Security/Response/addressResponse";
import { BaseResponse } from "../../../base-response";
import { PurchaseDetailResponse } from "./purchaseDetailResponse";

export interface OrderResponse extends BaseResponse {
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