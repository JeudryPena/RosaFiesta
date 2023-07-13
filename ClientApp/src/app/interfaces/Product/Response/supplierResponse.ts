import { ByBaseResponse } from "../../byBaseResponse";
import { ProductsListResponse } from "./productsListResponse";

export interface SupplierResponse extends ByBaseResponse {
    id: string;
    name: string;
    email: string | null;
    description: string | null;
    phone: string | null;
    address: string | null;
    products: ProductsListResponse[] | null;
}