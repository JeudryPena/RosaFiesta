import { BaseResponse } from "../../base-response";
import { DiscountPreviewResponse } from "./discountPreviewResponse";
import { ReviewPreviewResponse } from "./reviewPreviewResponse";

export interface OptionPreviewResponse extends BaseResponse {
	price: number;
	offerPrice: number | null;
	discountSave: number | null;
	images: string | null;
	stock: string;
	quantityAvaliable: number;
	condition: string;
	averageRating: number | null;
	totalReviews: number | null;
	reviews: ReviewPreviewResponse[] | null;
	discount: DiscountPreviewResponse | null;
	id: number;
}