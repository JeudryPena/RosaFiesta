import { BaseResponse } from "../../../baseResponse";
import { PurchaseDetailOptionResponse } from "./purchaseDetailOptionResponse";

export interface PurchaseDetailResponse extends BaseResponse {
    purchaseNumber: string;
    productId: string;
    purchaseOptions: PurchaseDetailOptionResponse[];
    cartId: string;
    orderId: string | null;
    quoteId: string | null;
}