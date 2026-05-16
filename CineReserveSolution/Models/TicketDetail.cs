using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TicketDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ShowtimeId { get; set; }

        [ForeignKey("ShowtimeId")]
        public Showtime Showtime { get; set; } = null!;

        [Required]
        public int BookingId { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; } = null!;

        [Required]
        public string Row { get; set; } = string.Empty;

        [Required]
        public int Number { get; set; }

        public decimal Price { get; set; }
    }
}