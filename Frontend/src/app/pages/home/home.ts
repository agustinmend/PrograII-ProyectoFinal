import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PublicacionService } from '../../services/publicacion.services';
import { PublicationBySearch } from '../../models/PublicationBySearch';


@Component({
  selector: 'app-home',
  imports: [CommonModule, FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
searchText: string = ''
  searchResults: PublicationBySearch[] = []
  isLoading: boolean = false
  backendUrl = 'http://localhost:5008'

  constructor(private publicacionService: PublicacionService) {}

  onSearch() {
    if (!this.searchText.trim()) return;

    this.isLoading = true;

    this.publicacionService.searchPublications(this.searchText).subscribe({
      next: (data) => {
        this.searchResults = data;
        this.isLoading = false;
        console.log("Resultados encontrados:", data);
      },
      error: (err) => {
        console.error("Error en la búsqueda:", err);
        this.isLoading = false;
      }
    });
  }
  
  clearSearch() {
    this.searchText = '';
    this.searchResults = [];
  }
}
