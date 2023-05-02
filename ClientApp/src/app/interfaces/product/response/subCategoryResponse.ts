export interface SubCategoryResponse extends BaseResponse {
    id: number;
    name: string;
    description: string;
    image: string;
    icon: string;
    slug: string;
    isActive: boolean;
    categoryId: number;
}