import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.services';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-register',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  showPassword : boolean = false
  user = {
    fullName : '',
    username: '',
    email: '',
    password: '',
    description: '',
  }
  selectedFile: File | null = null
  constructor(private userService : UserService, private router: Router) {}
  onFileSelected(event: any) {
    const file: File = event.target.files[0]
    if(file) {
      this.selectedFile = file
    }
  }
  onRegister() {
    this.userService.registerUser(this.user, this.selectedFile).subscribe({
      next: (response) => {
        console.log('Registro exitoso', response)
        alert('usuario registrado exitosamente')
        this.router.navigate(['/login'])
      },
      error: (error) => {
        console.log('Error al registrar', error)
        alert(error.error?.message || 'Error al registrar usuario')
      }
    })
  }
  togglePasswordVisibility() {
    this.showPassword = !this.showPassword
  }
}
