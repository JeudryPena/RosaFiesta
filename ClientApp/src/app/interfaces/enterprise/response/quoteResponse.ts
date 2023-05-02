import { QuoteItemResponse } from "./quoteItemResponse";

export interface QuoteResponse {
    id: number;
    customerName: string;
    contactNumber: string;
    extraInfo: string | null;
    email: string | null;
    eventName: string;
    eventDate: string;
    createdAt: string;
    location: string;
    quoteItems: QuoteItemResponse[];
    userId: string | null;
}