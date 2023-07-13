import { BaseResponse } from "../../baseResponse";
import { UserRoleResponse } from "./userRoleResponse";

export interface UsersResponse extends BaseResponse {
	id: string;
	userName: string;
	fullName: string;
	email: string;
	birthDate: Date;
	emailConfirmed: boolean;
	lockoutEnabled: boolean;
	accessFailedCount: number;
	lockoutEnd: string | null;
	promotionalMails: boolean;
	userRoles: UserRoleResponse[];
}