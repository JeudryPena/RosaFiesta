import { ByBaseResponse } from "../../by-base-response";

export interface ServiceResponse extends ByBaseResponse {
    id: string;
    name: string;
    description: string;
    price: number;
    image: string;
    quantity: number;
    quantityAvaliable: number;
}