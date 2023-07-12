import { BaseResponse } from "../../baseResponse";
import { OptionDetailResponse } from "./optionDetailResponse";
import { OptionPreviewResponse } from "./optionPreviewResponse";
import { WarrantiesListResponse } from "./warrantiesListResponse";

export interface ProductDetailResponse extends BaseResponse {
	id: string;
	categoryId: number | null;
	optionId: string | null;
	warranty: WarrantiesListResponse;
	option: OptionDetailResponse;
	options: OptionPreviewResponse[];
}