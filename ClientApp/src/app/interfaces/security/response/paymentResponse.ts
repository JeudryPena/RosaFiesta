export interface PaymentResponse {
    id: string;
    name: string;
    description: string;
    payMethodType: string;
    createdDate: string;
    updatedDate: string | null;
    userId: string;
}