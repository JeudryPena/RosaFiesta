import { BaseResponse } from "../../../base-response";
import { PurchaseDetailOptionResponse } from "./purchaseDetailOptionResponse";

export interface PurchaseDetailResponse extends BaseResponse {
    purchaseNumber: number;
    productId: string | null;
    totalOptionsPrice: number;
    purchaseOptions: PurchaseDetailOptionResponse[];
    cartId: number;
    orderId: number | null;
}