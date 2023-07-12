export interface OptionDetailResponse {
    id: string;
    description: string | null;
    images: MultipleImagesResponse[] | null;
    price: number;
    color: string | null;
    isMale: boolean | null;
    type: string;
    stock: string;
    quantityAvailable: number;
    offerPrice: number | null;
    discount: DiscountPreviewResponse | null;
    averageRating: number;
    totalReviews: number;
    reviews: ReviewResponse[] | null;
    condition: string;
}