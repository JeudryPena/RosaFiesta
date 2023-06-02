import { ProductsDiscountResponse } from "./productsDiscountResponse";

export interface DiscountResponse {
    code: string;
    name: string;
    type: string;
    value: number;
    maxTimesApply: number;
    start: string;
    end: string;
    description: string | null;
    productsDiscounts: ProductsDiscountResponse[];
}