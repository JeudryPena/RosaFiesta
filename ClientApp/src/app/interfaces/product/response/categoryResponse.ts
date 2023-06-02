import { ProductAndOptionResponse } from "./productAndOptionResponse";
import { SubCategoryResponse } from "./subCategoryResponse";

export interface CategoryResponse {
    id: number;
    name: string;
    description: string;
    icon: string;
    isActive: boolean;
    subCategories: SubCategoryResponse[] | null;
    products: ProductAndOptionResponse[] | null;
}