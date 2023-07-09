import { ProductsDto } from "./products-dto";

export interface WarrantyDto {
    name: string;
    type: number;
    period: number;
    description: string;
    conditions: string;
    warrantyProducts: ProductsDto[];
} 