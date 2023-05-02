export interface UserForCreationDto {
    userName: string;
    email: string;
    password: string;
    confirmPassword: string;
    birthDate: string;
    phoneNumber: string;
    name: string;
    lastName: string;
    civilStatus: number;
    address: string;
    city: string;
    state: string;
    promotionalMails: boolean;
}