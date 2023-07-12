export interface CartResponse {
    cartId: number;
    userId: string | null;
    details: PurchaseDetailResponse[] | null;
}