import { BaseResponse } from "../../baseResponse";

export interface ServiceResponse extends BaseResponse {
    id: string;
    name: string;
    description: string;
    price: number;
    image: string;
    quantity: number;
    quantityAvaliable: number;
}