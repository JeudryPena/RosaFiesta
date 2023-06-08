import { SubCategoryDto } from "./subCategoryDto";

export interface CategoryDto {
    name: string;
    description: string;
    icon: string;
    subCategories: SubCategoryDto[] | null;
}