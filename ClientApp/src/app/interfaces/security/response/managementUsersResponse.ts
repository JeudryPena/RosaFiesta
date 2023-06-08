import { BaseResponse } from "../../base-response";

export interface ManagementUsersResponse extends BaseResponse {
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
}