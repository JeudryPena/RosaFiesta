export interface WarrantiesManagementResponse extends ByBaseResponse {
    id: string;
    name: string | null;
    type: string;
    status: string;
    period: number;
    description: string;
    conditions: string;
    products: ProductsListResponse[];
}