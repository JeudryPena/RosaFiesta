import { BaseResponse } from "../../base-response";

export interface WarrantyPreviewResponse extends BaseResponse {
	id: string;
	name: string | null;
	type: string;
	scopeType: string;
	status: string | null;
	period: string;
	description: string;
	conditions: string;
}