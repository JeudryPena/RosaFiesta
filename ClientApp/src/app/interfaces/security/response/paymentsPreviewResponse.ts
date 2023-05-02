export interface PaymentsPreviewResponse {
    id: string;
    name: string;
    description: string;
    payMethodType: string;
    createdDate: string;
    isDefault: boolean | null;
}