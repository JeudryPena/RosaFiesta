export interface ManagementUsersResponse extends ByBaseResponse {
    id: string;
    userName: string;
    fullName: string;
    email: string;
    age: number;
    birthDate: DateOnly;
    phoneNumber: string;
    emailConfirmed: boolean;
    lockoutEnabled: boolean;
    lockoutEnd: string | null;
    userRoles: UserRoleResponse[];
}