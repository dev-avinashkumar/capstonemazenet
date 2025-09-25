import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface User {
  id?: number;
  username: string;
  email: string;
  passwordHash: string;
  firstName: string;
  lastName?: string;
  role: string;
  isActive: boolean;
  createdAt?: Date;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:7273/api/User';

  constructor(private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl);
  }
}
