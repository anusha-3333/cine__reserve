using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtos
{
    public class BookingRequestDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ShowtimeId { get; set; }

        [Required]
        public List<SeatDto> Seats { get; set; }
    }
}
