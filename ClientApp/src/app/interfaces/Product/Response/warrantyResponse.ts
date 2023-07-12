export interface WarrantyResponse extends ByBaseResponse {
    id: string;
    name: string | null;
    type: number;
    status: string;
    period: number;
    description: string;
    conditions: string;
    products: ProductsListResponse[];
}