export interface ReviewResponse {
    id: string;
    description: string | null;
    rating: number;
    date: string;
    updateDate: string | null;
    title: string | null;
    reviewerId: string;
    code: string;
    optionId: number | null;
}