import { ByBaseResponse } from "../../byBaseResponse";
import { CategoriesListResponse } from "./categoriesListResponse";
import { OptionsListResponse } from "./optionsListResponse";

export interface ManagementProductsResponse extends ByBaseResponse {
    id: string;
    code: string | null;
    isService: boolean;
    category: CategoriesListResponse;
    options: OptionsListResponse[];
}