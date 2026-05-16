using Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CineReserve.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _booking;

        public BookingController(IBookingService booking)
        {
            _booking = booking;
        }

        [Authorize]
        [HttpPost("book")]
        public async Task<IActionResult> BookSeats(BookingRequestDto dto)
        {
            var result = await _booking.BookSeats(dto);
            return Ok(new { bookingRef = result });
        }
    }
}
