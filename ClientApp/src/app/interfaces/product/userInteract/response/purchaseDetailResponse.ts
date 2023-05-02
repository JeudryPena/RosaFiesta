import { PurchaseDetailOptionResponse } from "./purchaseDetailOptionResponse";

export interface PurchaseDetailResponse {
    purchaseNumber: number;
    productId: string | null;
    totalOptionsPrice: number;
    purchaseOptions: PurchaseDetailOptionResponse[];
    cartId: number;
    orderSku: number | null;
}