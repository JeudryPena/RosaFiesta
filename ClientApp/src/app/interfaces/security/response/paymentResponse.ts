import { BaseResponse } from "../../base-response";

export interface PaymentResponse extends BaseResponse {
	id: string;
	name: string;
	description: string;
	payMethodType: string;
	userId: string;
}