import { ByBaseResponse } from "../../byBaseResponse";
import { ProductsDiscountResponse } from "./productsDiscountResponse";

export interface ManagementDiscountsResponse extends ByBaseResponse {
    id: string;
    value: number;
    start: string;
    end: string;
    productsDiscounts: ProductsDiscountResponse[] | null;
}