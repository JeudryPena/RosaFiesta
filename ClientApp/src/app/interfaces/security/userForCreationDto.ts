export interface UserForCreationDto {
	userName: string;
	email: string;
	password: string;
	confirmPassword: string;
	birthDate: Date;
	name: string;
	lastName: string;
	roleId: string[];
	promotionalMails: boolean;
}