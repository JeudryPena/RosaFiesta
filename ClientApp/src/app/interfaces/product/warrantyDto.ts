export interface WarrantyDto {
    name: string | null;
    type: number;
    scopeType: number;
    period: string;
    description: string;
    conditions: string;
}