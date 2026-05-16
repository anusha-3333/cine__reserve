using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtos
{
    public class SeatDto
    {
        [Required]
        public string Row { get; set; }

        [Required]
        public int Number { get; set; }

        public bool IsVIP { get; set; }
    }

}
