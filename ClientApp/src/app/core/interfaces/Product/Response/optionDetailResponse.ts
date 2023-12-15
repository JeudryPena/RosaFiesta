import { ReviewResponse } from "../UserInteract/Response/reviewResponse";
import { DiscountPreviewResponse } from "./discountPreviewResponse";
import { MultipleImagesResponse } from "./multipleImagesResponse";

export interface OptionDetailResponse {
    id: string;
    title: string
    description: string | null;
    images: MultipleImagesResponse[] | null;
    image: MultipleImagesResponse;
    price: number;
    color: string | null;
    genderFor: string;
    stock: string;
    quantityAvailable: number;
    offerPrice: number | null;
    discount: DiscountPreviewResponse | null;
    averageRating: number;
    totalReviews: number;
    reviews: ReviewResponse[] | null;
    condition: string;
}