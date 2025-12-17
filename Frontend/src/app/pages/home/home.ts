import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PublicacionService } from '../../services/publicacion.services';
import { PublicationBySearch } from '../../models/PublicationBySearch';
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  searchText: string = ''
  searchResults: PublicationBySearch[] = []
  isLoading: boolean = false
  backendUrl = 'http://localhost:5008'

  constructor(private router : Router) {}
  onSearch() {
    if (!this.searchText.trim()) return;

    // Navegamos a la ruta /search pasando el parámetro 'q'
    this.router.navigate(['/search'], { queryParams: { q: this.searchText } });
  }
}
