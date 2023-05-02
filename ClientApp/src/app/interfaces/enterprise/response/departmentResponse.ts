import { BaseResponse } from "../../baseResponse";
import { EmployePreviewResponse } from "./employePreviewResponse";

export interface DepartmentResponse extends BaseResponse {
    id: number;
    name: string;
    floor: number;
    description: string;
    employees: EmployePreviewResponse[] | null;
}