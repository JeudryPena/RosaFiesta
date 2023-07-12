export interface QuoteDto {
    customerName: string;
    contactNumber: string;
    extraInfo: string | null;
    email: string | null;
    eventName: string;
    eventDate: string;
    createdAt: string;
    location: string;
    quoteItems: PurchaseDetailDto[];
}