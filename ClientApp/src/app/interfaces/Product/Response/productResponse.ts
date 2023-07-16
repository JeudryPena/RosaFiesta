import { ByBaseResponse } from "../../byBaseResponse";
import { CategoriesListResponse } from "./categoriesListResponse";
import { OptionsResponse } from "./optionsResponse";
import { SuppliersListResponse } from "./suppliersListResponse";
import { WarrantiesListResponse } from "./warrantiesListResponse";

export interface ProductResponse extends ByBaseResponse {
    id: string;
    code: string;
    isService: boolean;
    option: OptionsResponse;
    category: CategoriesListResponse;
    warranty: WarrantiesListResponse | null;
    supplier: SuppliersListResponse | null;
    options: OptionsResponse[];
}