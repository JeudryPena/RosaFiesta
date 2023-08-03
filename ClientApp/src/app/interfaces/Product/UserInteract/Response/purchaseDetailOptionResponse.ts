import { BaseResponse } from "../../../baseResponse";
import { OptionCartResponse } from "../../Response/option-cart-response";

export interface PurchaseDetailOptionResponse extends BaseResponse {
    detailId: string;
    image: string;
    quantity: number;
    optionId: string;
    option: OptionCartResponse;
    unitPrice: number;
    appliedId: string | null;
    isReturned: boolean;
}