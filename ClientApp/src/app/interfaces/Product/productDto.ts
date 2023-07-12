import { CategoriesListResponse } from "./Response/categoriesListResponse";
import { SuppliersListResponse } from "./Response/suppliersListResponse";
import { WarrantiesListResponse } from "./Response/warrantiesListResponse";
import { OptionDto } from "./optionDto";

export interface ProductDto {
	code: string | null;
	isService: boolean;
	options: OptionDto[];
	category: CategoriesListResponse;
	warranty: WarrantiesListResponse | null;
	supplierId: SuppliersListResponse | null;
}