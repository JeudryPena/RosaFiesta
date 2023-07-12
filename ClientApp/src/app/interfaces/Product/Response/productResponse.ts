export interface ProductResponse extends ByBaseResponse {
    id: string;
    code: string;
    isService: boolean;
    categoryId: number;
    warrantyId: string | null;
    supplierId: string | null;
    options: OptionsResponse[];
}