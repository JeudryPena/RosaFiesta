export interface FinishRegisterResponse {
    id: string;
    message: string;
    isSuccess: boolean;
    email: string;
    userName: string;
    fullName: string;
    address: string;
    city: string;
    state: string;
}