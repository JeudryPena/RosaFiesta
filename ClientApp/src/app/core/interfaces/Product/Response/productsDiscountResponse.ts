import { OptionsListResponse } from "./optionsListResponse";

export interface ProductsDiscountResponse {
    discountId: string;
    optionId: string;
    option: OptionsListResponse;
}