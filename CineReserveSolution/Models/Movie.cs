using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Language { get; set; } = string.Empty;

        public int DurationMinutes { get; set; }

        public ICollection<Showtime> Showtimes { get; set; }
            = new List<Showtime>();
    }
}