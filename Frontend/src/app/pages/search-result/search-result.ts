import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router'; // Para leer la URL
import { CommonModule } from '@angular/common';
import { PublicacionService } from '../../services/publicacion.services';
import { PublicationBySearch } from '../../models/PublicationBySearch';

@Component({
  selector: 'app-search-results',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './search-result.html',
  styleUrl: './search-result.css'
})
export class SearchResultsComponent implements OnInit {
  apiUrl : string = 'http://localhost:5008/api'
  query: string = '';
  results: PublicationBySearch[] = [];
  isLoading: boolean = false;
  backendUrl = this.apiUrl.replace('/api', '')
  constructor(
    private route: ActivatedRoute,
    private publicacionService: PublicacionService
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.query = params['q'] || '';
      if (this.query) {
        this.performSearch(this.query);
      }
    });
  }

  performSearch(query: string) {
    this.isLoading = true;
    this.publicacionService.searchPublications(query).subscribe({
      next: (data) => {
        this.results = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error(err);
        this.isLoading = false;
      }
    });
  }
}