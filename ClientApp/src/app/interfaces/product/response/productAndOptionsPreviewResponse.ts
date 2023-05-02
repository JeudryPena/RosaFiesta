import { DiscountPreviewResponse } from "./discountPreviewResponse";
import { ReviewPreviewResponse } from "./reviewPreviewResponse";

export interface ProductAndOptionsPreviewResponse {
    code: string;
    title: string;
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
}