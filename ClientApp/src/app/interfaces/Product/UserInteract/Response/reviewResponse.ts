import { BaseResponse } from "../../../baseResponse";

export interface ReviewResponse extends BaseResponse {
    id: string;
    description: string | null;
    rating: number;
    title: string | null;
    userId: string;
    optionId: string;
}