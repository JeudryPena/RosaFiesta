import { ByBaseResponse } from "../../by-base-response";

export interface WarrantyResponse extends ByBaseResponse {
	id: string;
	name: string;
	type: string;
	status: string;
	period: number;
	description: string;
	conditions: string;
}