import { Weatherforecast } from './weatherforecast';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { immediateProvider } from 'rxjs/internal/scheduler/immediateProvider';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'Frontend';
  weatherForecastService = inject(Weatherforecast)
  climas : any[] = []
  constructor() {
    this.weatherForecastService.obtenerClima().subscribe(datos=> {
    this.climas = datos
    })
  }
}
