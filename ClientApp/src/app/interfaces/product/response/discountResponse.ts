import { BaseResponse } from "../../base-response";
import { ProductsDiscountResponse } from "./productsDiscountResponse";


export interface DiscountResponse extends BaseResponse {
	code: string;
	name: string;
	type: string;
	value: number;
	maxTimesApply: number;
	start: string;
	end: string;
	description: string | null;
	productsDiscounts: ProductsDiscountResponse[];
}