export interface PurchaseDetailOptionResponse {
    image: string;
    quantity: number;
    optionId: number;
    unitPrice: number;
    appliedId: number | null;
    totalPrice: number;
    createdAt: string;
    updatedAt: string | null;
    isReturned: boolean;
}