export interface OptionDetailResponse {
    purchaseNumber: number;
    quantity: number;
    unitPrice: number;
    appliedId: number | null;
    createdAt: string;
    updatedAt: string | null;
    optionId: number;
}