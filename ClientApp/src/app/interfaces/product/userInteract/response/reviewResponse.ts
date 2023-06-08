import { BaseResponse } from "../../../base-response";

export interface ReviewResponse extends BaseResponse {
    id: string;
    description: string | null;
    rating: number;
    title: string | null;
    userId: string;
    productCode: string;
    optionId: number | null;
}