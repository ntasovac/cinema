export interface User {
    id: number;
    email: string;
    passwordHash: string;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    birthDate: string;
    type: UserType;
    refreshToken?: string;
    refreshTokenExpiryTime?: Date;
}


export enum UserType {
    Admin = "Guest",
    Customer = "Admin",
  }