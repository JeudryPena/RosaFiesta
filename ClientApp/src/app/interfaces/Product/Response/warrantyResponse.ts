import { ByBaseResponse } from "../../byBaseResponse";
import { ProductsListResponse } from "./productsListResponse";

export interface WarrantyResponse extends ByBaseResponse {
    id: string;
    name: string | null;
    type: number;
    status: string;
    period: number;
    description: string;
    products: ProductsListResponse[];
}