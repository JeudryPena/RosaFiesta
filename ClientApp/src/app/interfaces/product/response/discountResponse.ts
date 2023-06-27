import { BaseResponse } from "../../base-response";
import { ProductsDiscountResponse } from "./productsDiscountResponse";


export interface DiscountResponse extends BaseResponse {
	id: string;
	name: string;
	type: number;
	value: number;
	maxTimesApply: number;
	start: string;
	end: string;
	description: string | null;
	productsDiscounts: ProductsDiscountResponse[];
}