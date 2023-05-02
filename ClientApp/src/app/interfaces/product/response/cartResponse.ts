import { PurchaseDetailResponse } from "../userInteract/response/purchaseDetailResponse";

export interface CartResponse {
    cartId: number;
    createdDate: string;
    updatedDate: string | null;
    userId: string | null;
    totalCartQuantity: number;
    totalCartPrice: number;
    details: PurchaseDetailResponse[] | null;
}