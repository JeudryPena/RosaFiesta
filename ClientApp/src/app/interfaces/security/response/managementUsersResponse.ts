import { ByBaseResponse } from "../../by-base-response";

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
}