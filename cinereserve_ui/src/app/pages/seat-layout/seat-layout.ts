import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-seat-layout',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './seat-layout.html',
  styleUrl: './seat-layout.css'
})
export class SeatLayout {

  rows = ['A','B','C','D','E','F','G','H'];
  cols = [1,2,3,4,5,6,7,8,9,10];

  selected: string[] = [];
  sold: string[] = [];

  total = 0;

  constructor(private router: Router) {}

  toggle(r: string, c: number) {
    const seat = r + c;

    if (this.sold.includes(seat)) return;

    if (this.selected.includes(seat)) {
      this.selected = this.selected.filter(s => s !== seat);
    } else {
      this.selected.push(seat);
    }

    this.calc();
  }

  getClass(r: string, c: number) {
    const seat = r + c;

    if (this.sold.includes(seat)) return 'sold';
    if (this.selected.includes(seat)) return 'selected';
    return 'available';
  }

  calc() {
    this.total = 0;

    this.selected.forEach(s => {
      const row = s.charAt(0);
      this.total += (row === 'G' || row === 'H') ? 300 : 150;
    });
  }

  goCheckout() {
    localStorage.setItem('seats', JSON.stringify(this.selected));
    localStorage.setItem('total', this.total.toString());
    this.router.navigate(['/checkout']);
  }
}