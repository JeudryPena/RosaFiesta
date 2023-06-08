import { BaseResponse } from "../../base-response";
import { QuoteItemResponse } from "./quoteItemResponse";

export interface QuoteResponse extends BaseResponse {
    id: number;
    customerName: string;
    contactNumber: string;
    extraInfo: string | null;
    email: string | null;
    eventName: string;
    eventDate: string;
    location: string;
    quoteItems: QuoteItemResponse[];
    userId: string | null;
}