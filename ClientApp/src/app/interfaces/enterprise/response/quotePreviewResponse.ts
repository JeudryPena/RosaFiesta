import { BaseResponse } from "../../base-response";

export interface QuotePreviewResponse extends BaseResponse {
    id: number;
    customerName: string;
    contactNumber: string;
    eventName: string;
    eventDate: string;
    location: string;
    userId: string | null;
}