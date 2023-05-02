import { QuoteItemDto } from "./quoteItemDto";

export interface QuoteUpdateDto {
    contactNumber: string;
    extraInfo: string | null;
    email: string | null;
    eventName: string;
    eventDate: string;
    createdAt: string;
    location: string;
    quoteItems: QuoteItemDto[] | null;
}