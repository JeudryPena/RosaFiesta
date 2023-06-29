import { ByBaseResponse } from "../../by-base-response";
import { CategoriesListResponse } from "./categories-list-response";
import { OptionsListResponse } from "./options-list-response";
import { SubCategoriesListResponse } from "./sub-categories-list-response";

export interface ManagementProductsResponse extends ByBaseResponse {
	id: string;
	code: string | null;
	name: string;
	brand: string;
	category: CategoriesListResponse;
	subCategory: SubCategoriesListResponse | null;
	options: OptionsListResponse[];
}