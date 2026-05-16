using Dtos;
using Models;
using Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using CineReserve.Data;

namespace Services
{
    public class BookingService : IBookingService
    {
        private readonly CineDbContext _context;

        public BookingService(CineDbContext context)
        {
            _context = context;
        }

        public async Task<string> BookSeats(BookingRequestDto dto)
        {
            using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                decimal total = 0;

                var booking = new Booking
                {
                    BookingRef = Guid.NewGuid()
                        .ToString()
                        .Substring(0, 8),

                    UserId = dto.UserId,

                    CreatedAt = DateTime.Now,

                    Tickets = new List<TicketDetail>()
                };

                foreach (var seat in dto.Seats)
                {
                    bool isBooked =
                        await _context.TicketDetails.AnyAsync(x =>
                            x.ShowtimeId == dto.ShowtimeId &&
                            x.Row == seat.Row &&
                            x.Number == seat.Number);

                    if (isBooked)
                    {
                        throw new Exception(
                            $"Seat {seat.Row}-{seat.Number} already booked"
                        );
                    }

                    decimal price = seat.IsVIP ? 300 : 150;

                    total += price;

                    booking.Tickets.Add(new TicketDetail
                    {
                        ShowtimeId = dto.ShowtimeId,
                        Row = seat.Row,
                        Number = seat.Number,
                        Price = price
                    });
                }

                booking.TotalAmount = total;

                _context.Bookings.Add(booking);

                Console.WriteLine("Before Save");

                await _context.SaveChangesAsync();

                Console.WriteLine("After Save");

                await transaction.CommitAsync();

                return booking.BookingRef;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                Console.WriteLine(ex.Message);

                throw;
            }
        }
    }
}