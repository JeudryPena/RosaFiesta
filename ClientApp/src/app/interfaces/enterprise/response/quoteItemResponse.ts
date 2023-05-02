import { BaseResponse } from "../../baseResponse";

export interface QuoteItemResponse extends BaseResponse {
    id: string;
    quantity: number;
    price: number;
    quoteId: string;
    serviceId: string;
}