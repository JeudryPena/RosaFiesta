export interface UsersResponse {
    id: string;
    fullName: string;
    email: string;
    userName: string;
    age: number;
    civilStatus: string;
    createdAt: string;
    updatedAt: string | null;
    birthDate: string;
    phoneNumber: string;
    twoFactorEnabled: boolean;
    phoneNumberConfirmed: boolean;
    emailConfirmed: boolean;
    lockoutEnabled: boolean;
    accessFailedCount: number;
    lockoutEnd: string | null;
    passwordHash: string | null;
    isLockedOut: boolean;
    promotionalMails: boolean;
    orders: OrderResponse[] | null;
    reviews: ReviewResponse[] | null;
    wishLists: WishListResponse[] | null;
    appliedDiscounts: AppliedDiscountResponse[] | null;
}