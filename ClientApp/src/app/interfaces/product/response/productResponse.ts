import { ReviewResponse } from "../UserInteract/Response/reviewResponse";
import { OptionPreviewResponse } from "./optionPreviewResponse";

export interface ProductResponse {
	id: string;
	title: string;
	brand: string | null;
	type: string;
	categoryId: number | null;
	warrantyId: string | null;
	supplierId: string | null;
	optionId: number;
	lastDate: string | null;
	averageRating: number | null;
	totalReviews: number | null;
	reviews: ReviewResponse[] | null;
	totalOptions: number;
	options: OptionPreviewResponse[];
}