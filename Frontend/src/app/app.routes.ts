import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';
import { Home } from './pages/home/home';
import { PublicacionComponent } from './pages/publicacion-component/publicacion-component';
import { Profile } from './pages/profile/profile';
import { SearchResultsComponent } from './pages/search-result/search-result';

export const routes: Routes = [
    {path: '', redirectTo: 'login', pathMatch: 'full'},
    {path: 'login', component: Login},
    {path: 'register', component: Register},
    {path: 'home', component: Home},
    {path: 'publication', component: PublicacionComponent},
    {path: 'profile/:id', component: Profile},
    {path: 'search', component: SearchResultsComponent},
    {path: '**', redirectTo: 'login'}    
];
