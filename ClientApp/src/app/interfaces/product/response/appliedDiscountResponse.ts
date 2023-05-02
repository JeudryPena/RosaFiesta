export interface AppliedDiscountResponse {
    id: number;
    userId: string;
    discountCode: string;
    timesApplied: number;
    appliedDate: string;
    orderId: number;
}