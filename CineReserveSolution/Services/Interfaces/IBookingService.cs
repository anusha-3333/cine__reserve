using Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IBookingService
    {
        Task<string> BookSeats(BookingRequestDto dto);
    }
}
