import { Routes } from '@angular/router';

import { LoginComponent } from './pages/login/login';
import { Movies } from './pages/movies/movies';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'movies', component: Movies }
];