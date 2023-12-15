import { ByBaseResponse } from "../../byBaseResponse";
import { UserRoleResponse } from "./userRoleResponse";

export interface UserResponse extends ByBaseResponse {
	id: string;
	userName: string;
	email: string;
	birthDate: Date;
	promotionalMails: boolean;
	userRoles: UserRoleResponse[];
}