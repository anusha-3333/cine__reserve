using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(2)]
        public string Row { get; set; }  // A-H

        [Required]
        public int Number { get; set; }  // 1-10

        public bool IsVIP { get; set; }
    }
}
