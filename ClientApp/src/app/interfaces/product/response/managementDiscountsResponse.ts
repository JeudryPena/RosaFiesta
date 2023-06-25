import { ByBaseResponse } from "../../by-base-response";
import { ProductsDiscountResponse } from "./productsDiscountResponse";

export interface ManagementDiscountsResponse extends ByBaseResponse {
	code: string;
	name: string;
	type: number;
	value: number;
	maxTimesApply: number;
	start: string;
	end: string;
	description: string | null;
	productsDiscounts: ProductsDiscountResponse[];
}