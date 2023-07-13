import { ByBaseResponse } from "../../byBaseResponse";
import { UserRoleResponse } from "./userRoleResponse";

export interface ManagementUsersResponse extends ByBaseResponse {
    id: string;
    userName: string;
    fullName: string;
    email: string;
    age: number;
    birthDate: Date;
    emailConfirmed: boolean;
    lockoutEnabled: boolean;
    lockoutEnd: string | null;
    userRoles: UserRoleResponse[];
}