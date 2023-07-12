import { ProductsDto } from "./productsDto";

export interface SupplierDto {
    name: string;
    email: string | null;
    phone: string | null;
    description: string | null;
    address: string | null;
    products: ProductsDto[] | null;
}