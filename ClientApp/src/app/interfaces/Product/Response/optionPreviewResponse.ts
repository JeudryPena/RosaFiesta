import { BaseResponse } from "../../baseResponse";
import { DiscountPreviewResponse } from "./discountPreviewResponse";
import { MultipleImagesResponse } from "./multipleImagesResponse";
import { ReviewPreviewResponse } from "./reviewPreviewResponse";

export interface OptionPreviewResponse extends BaseResponse {
    id: string;
    price: number;
    offerPrice: number | null;
    discountSave: number | null;
    images: MultipleImagesResponse[] | null;
    stock: string;
    quantityAvailable: number;
    condition: string;
    averageRating: number | null;
    totalReviews: number | null;
    reviews: ReviewPreviewResponse[] | null;
    discount: DiscountPreviewResponse | null;
}