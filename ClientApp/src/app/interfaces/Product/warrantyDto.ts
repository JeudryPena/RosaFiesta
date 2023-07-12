import { ProductsDto } from "./productsDto";

export interface WarrantyDto {
    name: string;
    type: number;
    period: number;
    description: string;
    warrantyProducts: ProductsDto[] | null;
}