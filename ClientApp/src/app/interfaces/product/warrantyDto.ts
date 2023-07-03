import { WarrantyProductsDto } from "./warranty-products-dto";

export interface WarrantyDto {
    name: string;
    type: number;
    period: number;
    description: string;
    conditions: string;
    products: WarrantyProductsDto[];
}