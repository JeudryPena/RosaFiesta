import { PurchaseDetailResponse } from "../../Product/UserInteract/Response/purchaseDetailResponse";
import { BaseResponse } from "../../baseResponse";

export interface QuoteResponse extends BaseResponse {
    id: string;
    customerName: string;
    contactNumber: string;
    extraInfo: string | null;
    email: string | null;
    eventName: string;
    eventDate: string;
    location: string;
    quoteItems: PurchaseDetailResponse[];
    userId: string | null;
}