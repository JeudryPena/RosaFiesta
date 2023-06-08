import { PurchaseDetailResponse } from "../UserInteract/Response/purchaseDetailResponse";

export interface CartResponse {
	cartId: number;
	userId: string | null;
	totalCartQuantity: number;
	totalCartPrice: number;
	details: PurchaseDetailResponse[] | null;
}