export interface ValidDiscountResponse {
    discountCode: string;
    discountType: string;
    discountValue: number;
    discountDescription: string | null;
    isValid: boolean;
    responseMessage: string | null;
}