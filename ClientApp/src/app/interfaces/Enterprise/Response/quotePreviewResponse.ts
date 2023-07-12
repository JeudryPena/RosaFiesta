export interface QuotePreviewResponse extends BaseResponse {
    id: string;
    customerName: string;
    contactNumber: string;
    eventName: string;
    eventDate: string;
    location: string;
    userId: string | null;
}