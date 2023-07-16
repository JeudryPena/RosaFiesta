import { BaseResponse } from "../../baseResponse";
import { DiscountPreviewResponse } from "./discountPreviewResponse";
import { MultipleImagesResponse } from "./multipleImagesResponse";
import { ProductsDiscountPreviewResponse } from "./products-discount-preview-response";
import { ReviewPreviewResponse } from "./reviewPreviewResponse";

export interface OptionPreviewResponse extends BaseResponse {
    id: string;
    price: number;
    image: MultipleImagesResponse[] | null;
    quantityAvailable: number;
    condition: string;
    genderFor: string;
    averageRating: number | null;
    totalReviews: number | null;
    reviews: ReviewPreviewResponse[] | null;
    productsDiscount: ProductsDiscountPreviewResponse | null;
}