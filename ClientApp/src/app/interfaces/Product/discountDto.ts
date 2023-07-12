export interface DiscountDto {
    value: number;
    start: string;
    end: string;
    productsDiscounts: ProductsDiscountDto[] | null;
}