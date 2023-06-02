import { ReviewResponse } from "../userInteract/response/reviewResponse";
import { DiscountPreviewResponse } from "./discountPreviewResponse";
import { MultipleImagesResponse } from "./multipleImagesResponse";
import { OptionPreviewResponse } from "./optionPreviewResponse";

export interface ProductAndOptionDetailResponse {
    code: string;
    title: string;
    description: string | null;
    images: MultipleImagesResponse[] | null;
    price: number;
    offerPrice: number | null;
    discountSave: number | null;
    stock: string;
    quantityAvaliable: number;
    brand: string | null;
    color: string | null;
    size: number | null;
    weight: number;
    genderFor: string | null;
    material: string | null;
    type: string;
    condition: string;
    categoryId: number | null;
    lastReviewDate: string;
    averageRating: number;
    totalReviews: number;
    totalSales: number;
    reviews: ReviewResponse[] | null;
    totalOptions: number | null;
    options: OptionPreviewResponse[];
    optionId: number | null;
    warrantyId: string;
    discount: DiscountPreviewResponse | null;
    warrantyName: string | null;
}