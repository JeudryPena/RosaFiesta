import { ByBaseResponse } from "../../by-base-response";
import { OptionPreviewResponse } from "./optionPreviewResponse";
import { OptionResponse } from "./optionResponse";

export interface ProductResponse extends ByBaseResponse {
	id: string;
	code: string;
	name: string;
	brand: string | null;
	categoryId: number;
	subCategoryId: number | null;
	warrantyId: string | null;
	supplierId: string | null;
	options: OptionResponse[];
}