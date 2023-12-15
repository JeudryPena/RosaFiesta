import { PurchaseDetailResponse } from "../UserInteract/Response/purchaseDetailResponse";

export interface CartResponse {
    cartId: number;
    userId: string | null;
    details: PurchaseDetailResponse[] | null;
}