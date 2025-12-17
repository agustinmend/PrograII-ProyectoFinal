import { Component } from '@angular/core';
import { PublicacionService } from '../../services/publicacion.services';
import { Publication } from '../../models/publication';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-publicacion-component',
  imports: [CommonModule],
  templateUrl: './publicacion-component.html',
  styleUrl: './publicacion-component.css',
})
export class PublicacionComponent {
  PublicationList : Publication[] = []
  constructor(private publicationServices : PublicacionService) { }
}
