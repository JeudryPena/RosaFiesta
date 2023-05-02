export interface RegisterDto {
    userName: string;
    email: string;
    password: string;
    confirmPassword: string;
    birthDate: string;
    phoneNumber: string;
    termsAndConditionsAccepted: boolean;
}