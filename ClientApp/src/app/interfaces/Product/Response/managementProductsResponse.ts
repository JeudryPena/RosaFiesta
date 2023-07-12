export interface ManagementProductsResponse extends ByBaseResponse {
    id: string;
    code: string | null;
    isService: boolean;
    category: CategoriesListResponse;
    options: OptionsListResponse[];
}