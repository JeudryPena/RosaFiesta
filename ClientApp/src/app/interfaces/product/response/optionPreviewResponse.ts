import { DiscountPreviewResponse } from "./discountPreviewResponse";
import { ReviewPreviewResponse } from "./reviewPreviewResponse";

export interface OptionPreviewResponse {
    id: number;
    price: number;
    images: string | null;
    stock: string;
    quantityAvaliable: number;
    averageRating: number | null;
    totalReviews: number | null;
    reviews: ReviewPreviewResponse[] | null;
    discount: DiscountPreviewResponse | null;
}