import { Component } from '@angular/core';
import { Router ,RouterLink } from "@angular/router";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.services';

@Component({
  selector: 'app-login',
  imports: [CommonModule, FormsModule,RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  
  showPassword: boolean = false;

  credentials = {
    username: '',
    password: ''
  };

  constructor(private userService: UserService, private router: Router) {}

  onLogin() {
    this.userService.login(this.credentials).subscribe({
      next: (response: any) => {
        if (response && response.id) {
          this.userService.saveUserId(response.id); 
          this.router.navigate(['/home']);
        }
      },
      error: (error) => {
        console.error('Error login:', error);
        alert(error.error?.message || 'Error al iniciar sesión');
      }
    });
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }
}
