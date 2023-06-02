import { ReviewResponse } from "../userInteract/response/reviewResponse";
import { OptionPreviewResponse } from "./optionPreviewResponse";

export interface ProductAndOptionResponse {
    code: string | null;
    title: string;
    description: string | null;
    price: number;
    images: string | null;
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
    warrantyId: string | null;
    supplierId: string | null;
    optionId: number;
    lastReviewDate: string | null;
    averageRating: number | null;
    totalReviews: number | null;
    reviews: ReviewResponse[] | null;
    totalOptions: number;
    options: OptionPreviewResponse[];
}