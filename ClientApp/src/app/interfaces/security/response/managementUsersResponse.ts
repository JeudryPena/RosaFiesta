import { ByBaseResponse } from "../../by-base-response";
import { UserRoleResponse } from "./user-role-response";

export interface ManagementUsersResponse extends ByBaseResponse {
	id: string;
	fullName: string;
	email: string;
	userName: string;
	age: number;
	birthDate: string;
	phoneNumber: string;
	emailConfirmed: boolean;
	lockoutEnabled: boolean;
	lockoutEnd: string | null;
	userRoles: UserRoleResponse[];
}