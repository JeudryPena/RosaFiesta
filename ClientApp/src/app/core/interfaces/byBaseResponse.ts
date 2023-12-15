import { BaseResponse } from "./baseResponse";

export interface ByBaseResponse extends BaseResponse {
	createdBy: string;
	updatedBy: string | null;
}