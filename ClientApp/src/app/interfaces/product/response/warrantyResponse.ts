import { ByBaseResponse } from "../../by-base-response";
import { ProductsListResponse } from "./products-list-response";

export interface WarrantyResponse extends ByBaseResponse {
	id: string;
	name: string;
	type: string;
	status: string;
	period: number;
	description: string;
	conditions: string;
	products: ProductsListResponse[];
}