import { ProductsDiscountDto } from "./productsDiscountDto";

export interface DiscountDto {
    code: string;
    name: string;
    type: number;
    start: string;
    end: string;
    value: number;
    maxTimesApply: number;
    description: string | null;
    productsDiscounts: ProductsDiscountDto[];
}