import { BaseResponse } from "../../base-response";
import { ProductResponse } from "./productResponse";
import { SubCategoryResponse } from "./subCategoryResponse";

export interface CategoryResponse extends BaseResponse {
	id: number;
	name: string;
	description: string;
	icon: string;
	subCategories: SubCategoryResponse[] | null;
	products: ProductResponse[] | null;
}