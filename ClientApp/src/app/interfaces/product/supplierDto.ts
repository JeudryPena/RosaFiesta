import { WarrantyProductsDto as ProductsDto } from "./warranty-products-dto";

export interface SupplierDto {
    name: string;
    email: string | null;
    phone: string | null;
    description: string | null;
    address: string;
    products: ProductsDto[];
}