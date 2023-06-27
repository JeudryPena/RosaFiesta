import { OptionPreviewResponse } from "./optionPreviewResponse";

export interface ProductPreviewResponse {
	discountId: string;
	title: string;
	options: OptionPreviewResponse;
}