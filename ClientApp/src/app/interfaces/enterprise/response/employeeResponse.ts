import { BaseResponse } from "../../baseResponse";

export interface EmployeeResponse extends BaseResponse {
    id: string;
    fullName: string;
    email: string;
    phone: string;
    departmentId: number;
    jobTitle: string;
    address: string;
    salary: number;
    workingHours: string;
    workingDays: string;
    resume: string | null;
    photo: string;
    identityCard: string;
}