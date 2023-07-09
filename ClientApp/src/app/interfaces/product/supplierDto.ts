import { ProductsDto } from "./products-dto";

export interface SupplierDto {
    name: string;
    email: string | null;
    phone: string | null;
    description: string | null;
    address: string;
    products: ProductsDto[];
}