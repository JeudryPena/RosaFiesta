import { WarrantyProductsDto } from "./warranty-products-dto";

export interface WarrantyDto {
    name: string;
    type: number;
    status: number;
    period: number;
    description: string;
    conditions: string;
    products: WarrantyProductsDto[];
}