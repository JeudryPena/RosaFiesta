import { ProductsDiscountDto } from "./productsDiscountDto";

export interface DiscountDto {
    code: string;
    name: string;
    type: number;
    discount: number;
    start: string;
    end: string;
    description: string | null;
    productsDiscount: ProductsDiscountDto[];
}