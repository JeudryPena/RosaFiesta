export interface UserForCreationDto {
	userName: string;
	email: string;
	password: string;
	confirmPassword: string;
	birthDate: Date;
	phoneNumber: string;
	name: string;
	lastName: string;
	roleId: string[];
	promotionalMails: boolean;
}