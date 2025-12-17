import { Weatherforecast } from './weatherforecast';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { immediateProvider } from 'rxjs/internal/scheduler/immediateProvider';
import { Home } from './pages/home/home';
import { Profile } from './pages/profile/profile';
import { CreatePublication } from './pages/create-publication/create-publication';
import { PublicacionComponent } from "./pages/publicacion-component/publicacion-component";
import { Register } from './pages/register/register';
import { Login } from './pages/login/login';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Home, Profile, CreatePublication, PublicacionComponent, Register , Login],
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
