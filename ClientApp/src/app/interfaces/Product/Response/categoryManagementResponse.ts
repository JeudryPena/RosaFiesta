import { ByBaseResponse } from "../../byBaseResponse";

export interface CategoryManagementResponse extends ByBaseResponse {
    id: number;
    name: string;
    icon: string;
    description: string | null;
}