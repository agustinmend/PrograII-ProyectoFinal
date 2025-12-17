import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { PublicacionService } from '../../services/publicacion.services';
import { UserService } from '../../services/user.services';

@Component({
  selector: 'app-create-publication',
  imports: [CommonModule, FormsModule],
  templateUrl: './create-publication.html',
  styleUrl: './create-publication.css',
})
export class CreatePublication {
content: string = '';
  selectedFiles: File[] = [];
  previews: string[] = [];
  isLoading: boolean = false;

  constructor(
    private publicacionService: PublicacionService,
    private userService : UserService,
    private router: Router
  ) {}

  onFileSelected(event: any) {
    const files = event.target.files;
    if (files) {
      for (let file of files) {
        this.selectedFiles.push(file);
        const reader = new FileReader();
        reader.onload = (e: any) => this.previews.push(e.target.result);
        reader.readAsDataURL(file);
      }
    }
  }

  onSubmit() {
    const  authorId = this.userService.getUserId()
    if (!authorId) {
      alert("Debes iniciar sesión para publicar");
      this.router.navigate(['/login']);
      return;
    }
    if (!this.content.trim() && this.selectedFiles.length === 0) return;

    this.isLoading = true;
  
    this.publicacionService.createPublication(this.content, authorId, this.selectedFiles).subscribe({
      next: () => {
        alert('¡Publicación creada con éxito!');
        this.router.navigate(['/home']);
      },
      error: (err) => {
        console.error('Error al publicar:', err);
        this.isLoading = false;
      }
    });
  }

  cancel() {
    this.router.navigate(['/home']);
  }
}
