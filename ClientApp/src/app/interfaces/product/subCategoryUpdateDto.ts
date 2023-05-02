export interface SubCategoryUpdateDto {
    name: string;
    description: string;
    icon: string;
    slug: string;
    isActive: boolean;
    categoryId: number;
}