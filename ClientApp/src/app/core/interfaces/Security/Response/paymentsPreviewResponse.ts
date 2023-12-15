import { BaseResponse } from "../../baseResponse";

export interface PaymentsPreviewResponse extends BaseResponse {
    id: string;
    name: string;
    isDefault: boolean | null;
}