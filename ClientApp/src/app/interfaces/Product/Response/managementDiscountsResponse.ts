export interface ManagementDiscountsResponse extends ByBaseResponse {
    id: string;
    value: number;
    start: string;
    end: string;
    productsDiscounts: ProductsDiscountResponse[] | null;
}