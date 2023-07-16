import { ByBaseResponse } from "../../byBaseResponse";
import { UserRoleResponse } from "./userRoleResponse";

export interface ManagementUsersResponse extends ByBaseResponse {
    id: string;
    userName: string;
    fullName: string;
    email: string;
    birthDate: Date;
    emailConfirmed: boolean;
    lockoutEnd: string | null;
    userRoles: UserRoleResponse[];
}