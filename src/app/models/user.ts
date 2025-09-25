export interface User {
  id: number;
  username: string;
  email: string;
  passwordHash: string;
  firstName: string;
  lastName: string;
  role: string;
  isActive: boolean;
  createdAt: string;
}
