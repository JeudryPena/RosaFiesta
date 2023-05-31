import { SubCategoryDto } from "./subCategoryDto";

export interface CategoryDto {
    name: string;
    description: string;
    icon: string;
    isActive: boolean;
    subCategories: SubCategoryDto[] | null;
}