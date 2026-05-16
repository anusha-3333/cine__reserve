import { Component } from '@angular/core';
import { Booking } from '../../services/booking';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkout',
  standalone: true,
  templateUrl: './checkout.html',
  styleUrl: './checkout.css'
})
export class Checkout {

  seats: any;
  total: any;

  constructor(private booking: Booking, private router: Router) {
    this.seats = JSON.parse(localStorage.getItem('seats') || '[]');
    this.total = localStorage.getItem('total');
  }
  book() {
    const payload = {
      seats: this.seats,
      total: this.total,
      showtimeId: 1
    };

    this.booking.book(payload).subscribe(() => {
      alert("Booking Successful!");
      this.router.navigate(['/movies']);
    });
  }
}