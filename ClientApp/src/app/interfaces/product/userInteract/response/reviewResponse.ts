export interface ReviewResponse {
    id: string;
    reviewDescription: string | null;
    reviewRating: number;
    reviewDate: string;
    reviewUpdateDate: string | null;
    reviewTittle: string | null;
    userReviewerId: string;
    productCode: string;
    optionId: number | null;
}