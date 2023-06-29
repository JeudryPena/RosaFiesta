import { BaseResponse } from "../../base-response";
import { OptionDetailResponse } from "./optionDetailResponse";
import { OptionPreviewResponse } from "./optionPreviewResponse";

export interface ProductDetailResponse extends BaseResponse {
	id: string;
	name: string;
	brand: string | null;
	categoryId: number | null;
	optionId: number | null;
	warrantyId: string;
	warrantyName: string | null;
	option: OptionDetailResponse;
	options: OptionPreviewResponse[];
}