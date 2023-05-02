import { SubCategoryPreviewResponse } from "./subCategoryPreviewResponse";

export interface CategoryPreviewResponse {
    id: number;
    title: string;
    icon: string;
    description: string | null;
    subCategories: SubCategoryPreviewResponse[] | null;
}