import { BaseResponse } from "./base-response";

export interface ByBaseResponse extends BaseResponse {
    createdBy: string;
    updatedBy: string;
}
