import { Component } from '@angular/core';
import { Movie } from '../../services/movie';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-movies',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './movies.html',
  styleUrl: './movies.css'
})
export class Movies {

  movies: any[] = [];

  constructor(private movie: Movie, private router: Router) {}

  ngOnInit() {
    this.movie.getMovies().subscribe(res => {
      this.movies = res as any[];
    });
  }

  openSeats(id: number) {
    localStorage.setItem('movieId', id.toString());
    this.router.navigate(['/seats']);
  }
}