import { ProductsDiscountDto } from "./productsDiscountDto";

export interface DiscountDto {
    discountCode: string;
    discountName: string;
    discountType: number;
    discount: number;
    discountStartDate: string;
    discountEndDate: string;
    discountDescription: string | null;
    discountImage: string | null;
    productsDiscount: ProductsDiscountDto[];
}