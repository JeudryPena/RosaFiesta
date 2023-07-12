export interface UserForUpdateDto {
	userName: string;
	name: string;
	lastName: string;
	birthDate: DateOnly;
	roleId: string[];
}