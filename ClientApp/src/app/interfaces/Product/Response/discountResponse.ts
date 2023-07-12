export interface DiscountResponse extends BaseResponse {
    id: string;
    value: number;
    start: string;
    end: string;
    productsDiscounts: ProductsDiscountResponse[] | null;
}