import { OptionPreviewResponse } from "./optionPreviewResponse";

export interface ProductPreviewResponse {
	discountId: string;
	name: string;
	options: OptionPreviewResponse;
}