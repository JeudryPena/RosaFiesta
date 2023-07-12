export interface PurchaseDetailOptionResponse extends BaseResponse {
    image: string;
    quantity: number;
    optionId: string;
    unitPrice: number;
    appliedId: string | null;
    isReturned: boolean;
}