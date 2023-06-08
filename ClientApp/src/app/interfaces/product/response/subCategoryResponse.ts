import { BaseResponse } from "../../base-response";

export interface SubCategoryResponse extends BaseResponse {
	id: number;
	name: string;
	description: string;
	icon: string;
	isActive: boolean;
	categoryId: number;
}