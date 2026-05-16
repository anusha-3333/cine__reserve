using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Showtime
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        [Required]
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; } = null!;

        public ICollection<TicketDetail> Tickets { get; set; }
            = new List<TicketDetail>();
    }
}