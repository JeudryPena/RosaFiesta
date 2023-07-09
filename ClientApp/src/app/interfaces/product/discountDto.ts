import { ProductsDiscountDto } from "./productsDiscountDto";

export interface DiscountDto {
    name: string; 
    type: number;
    start: string;
    end: string;
    value: number;
    maxTimesApply: number;
    description: string | null;
    productsDiscounts: ProductsDiscountDto[];
}