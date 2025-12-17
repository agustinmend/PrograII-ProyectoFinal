import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PublicationBySearch } from '../models/PublicationBySearch';

@Injectable({
  providedIn: 'root'
})
export class PublicacionService {
  private apiUrl = 'http://localhost:5008/api/Publications'

  constructor(private http: HttpClient) { }

  searchPublications(query: string, type: string = 'normal'): Observable<PublicationBySearch[]> {
    let params = new HttpParams()
        .set('query', query)
        .set('type', type);

    return this.http.get<PublicationBySearch[]>(`${this.apiUrl}/search`, { params });
  }
  createPublication(content: string, authorId: string, images: File[]): Observable<any> {
    const formData = new FormData();
    formData.append('Content', content);
    formData.append('AuthorId', authorId);
    
    images.forEach(file => {
      formData.append('Images', file);
    });

    return this.http.post(this.apiUrl, formData);
  }
}