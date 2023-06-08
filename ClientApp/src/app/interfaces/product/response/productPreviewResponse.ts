import { OptionPreviewResponse } from "./optionPreviewResponse";

export interface ProductPreviewResponse {
	code: string;
	title: string;
	options: OptionPreviewResponse;
}