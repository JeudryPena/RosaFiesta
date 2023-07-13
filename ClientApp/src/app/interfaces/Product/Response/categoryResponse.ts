import { BaseResponse } from "../../baseResponse";
import { ProductResponse } from "./productResponse";

export interface CategoryResponse extends BaseResponse {
    id: number;
    name: string;
    description: string;
    icon: string;
    products: ProductResponse[] | null;
}