export interface SupplierResponse extends BaseResponse {
    id: string;
    name: string;
    email: string | null;
    description: string | null;
    phone: string | null;
    address: string | null;
    productsSupplied: ProductResponse[] | null;
}