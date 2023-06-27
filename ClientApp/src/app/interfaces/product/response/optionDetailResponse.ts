import { ReviewResponse } from "../UserInteract/Response/reviewResponse";
import { DiscountPreviewResponse } from "./discountPreviewResponse";
import { MultipleImagesResponse } from "./multipleImagesResponse";

export interface OptionDetailResponse {
	id: number;
	title: string;
	description: string | null;
	images: MultipleImagesResponse[] | null;
	price: number;
	color: string | null;
	size: number | null;
	weight: number;
	genderFor: string | null;
	material: string | null;
	type: string;
	stock: string;
	quantityAvaliable: number;
	offerPrice: number | null;
	discountSave: number | null;
	discount: DiscountPreviewResponse | null;
	averageRating: number;
	totalReviews: number;
	totalSales: number;
	reviews: ReviewResponse[] | null;
	condition: string;
}