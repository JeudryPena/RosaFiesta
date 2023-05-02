import { BaseResponse } from "../../baseResponse";
import { ProductsDiscountResponse } from "./productsDiscountResponse";

export interface DiscountResponse extends BaseResponse {
    discountCode: string;
    discountName: string;
    discountType: string;
    discountValue: number;
    maxTimesApply: number;
    discountStartDate: string;
    discountEndDate: string;
    discountDescription: string | null;
    discountImage: string | null;
    productsDiscounts: ProductsDiscountResponse[];
}