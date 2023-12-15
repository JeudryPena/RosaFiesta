import { BaseResponse } from "../../baseResponse";

export interface PaymentResponse extends BaseResponse {
    id: string;
    name: string;
    userId: string;
}