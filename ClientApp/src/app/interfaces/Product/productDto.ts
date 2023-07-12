export interface ProductDto {
	code: string | null;
	isService: boolean;
	options: OptionDto[];
	category: CategoriesListResponse;
	warranty: WarrantiesListResponse | null;
	supplierId: SuppliersListResponse | null;
}