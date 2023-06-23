import { BaseResponse } from "../../base-response";
import { ProductsDiscountResponse } from "./productsDiscountResponse";

export interface ManagementDiscountsResponse extends BaseResponse {
	code: string; 
	name: string;
	type: number;
	value: number;
	maxTimesApply: number;
	start: string;
	end: string;
	createdBy: string;
	updatedBy: string;
	description: string | null;
	productsDiscounts: ProductsDiscountResponse[];
}