import { ProductAndOptionResponse } from "./productAndOptionResponse";

export interface SupplierResponse {
    id: string;
    name: string;
    email: string | null;
    description: string | null;
    phone: string | null;
    address: string;
    productsSupplied: ProductAndOptionResponse[] | null;
}