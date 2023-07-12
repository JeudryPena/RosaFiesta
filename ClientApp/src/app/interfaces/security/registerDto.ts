export interface RegisterDto {
    userName: string;
    name: string;
    lastName: string;
    phoneNumber: string;
    promotionalMails: boolean;
    email: string;
    password: string;
    confirmPassword: string;
    birthDate: DateOnly;
}