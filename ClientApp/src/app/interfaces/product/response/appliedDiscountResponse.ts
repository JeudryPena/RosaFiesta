export interface AppliedDiscountResponse {
    id: number;
    userId: string;
    code: string;
    timesApplied: number;
    appliedDate: string;
    orderId: number;
}