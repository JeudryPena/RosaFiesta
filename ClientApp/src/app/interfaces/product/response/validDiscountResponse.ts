export interface ValidDiscountResponse {
    code: string;
    type: string;
    value: number;
    description: string | null;
    isValid: boolean;
    responseMessage: string | null;
}