import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from '../../services/user.service';

interface User {
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

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  users: User[] = [];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe({
      next: (data: User[]) => this.users = data,
      error: (err: any) => console.error('Error loading users', err)
    });
  }
}
