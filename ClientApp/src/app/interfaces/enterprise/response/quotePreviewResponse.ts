export interface QuotePreviewResponse {
    id: number;
    customerName: string;
    contactNumber: string;
    eventName: string;
    eventDate: string;
    createdAt: string;
    location: string;
    userId: string | null;
}