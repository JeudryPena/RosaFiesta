import { UserRolesDto } from "./user-roles-dto";

export interface UserForCreationDto {
	userName: string;
	email: string;
	password: string;
	confirmPassword: string;
	birthDate: string;
	rolesId: UserRolesDto[];
	promotionalMails: boolean;
}