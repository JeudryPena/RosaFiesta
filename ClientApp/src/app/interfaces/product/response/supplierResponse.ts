import { BaseResponse } from "../../base-response";
import { ProductResponse } from "./productResponse";

export interface SupplierResponse extends BaseResponse {
	id: string;
	name: string;
	email: string | null;
	description: string | null;
	phone: string | null;
	address: string;
	productsSupplied: ProductResponse[] | null;
}