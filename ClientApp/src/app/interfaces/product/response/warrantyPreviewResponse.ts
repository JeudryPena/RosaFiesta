export interface WarrantyPreviewResponse {
    id: string;
    name: string | null;
    type: string;
    scopeType: string;
    status: string | null;
    period: string;
    description: string;
    conditions: string;
}