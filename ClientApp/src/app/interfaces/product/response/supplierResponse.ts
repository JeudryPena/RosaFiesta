import { ByBaseResponse } from "../../by-base-response";
import { ProductsListResponse } from "./products-list-response";

export interface SupplierResponse extends ByBaseResponse {
	id: string;
	name: string;
	email: string | null;
	description: string | null;
	phone: string | null;
	address: string;
	products: ProductsListResponse[] | null;
}