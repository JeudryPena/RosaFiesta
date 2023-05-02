import { BaseResponse } from "../../baseResponse";
import { ProductAndOptionResponse } from "./productAndOptionResponse";

export interface SupplierResponse extends BaseResponse {
    id: string;
    name: string;
    email: string | null;
    description: string | null;
    phone: string | null;
    address: string;
    productsSupplied: ProductAndOptionResponse[] | null;
}