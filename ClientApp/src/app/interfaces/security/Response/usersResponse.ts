export interface UsersResponse extends BaseResponse {
	id: string;
	userName: string;
	fullName: string;
	email: string;
	birthDate: DateOnly;
	phoneNumber: string;
	emailConfirmed: boolean;
	lockoutEnabled: boolean;
	accessFailedCount: number;
	lockoutEnd: string | null;
	promotionalMails: boolean;
	userRoles: UserRoleResponse[];
}