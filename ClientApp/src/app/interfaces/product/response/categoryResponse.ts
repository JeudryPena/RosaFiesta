import { BaseResponse } from "../../baseResponse";
import { ProductAndOptionResponse } from "./productAndOptionResponse";
import { SubCategoryResponse } from "./subCategoryResponse";

export interface CategoryResponse extends BaseResponse {
    id: number;
    name: string;
    description: string;
    image: string;
    icon: string;
    slug: string;
    isActive: boolean;
    subCategories: SubCategoryResponse[] | null;
    products: ProductAndOptionResponse[] | null;
}