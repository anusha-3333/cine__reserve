using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;
using CineReserve.Data;

namespace CineReserve.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ShowsController : ControllerBase
        {
            private readonly CineDbContext  _context;

            public ShowsController(CineDbContext context)
            {
                _context = context;
            }

            [HttpGet("{movieId}")]
            public async Task<IActionResult> GetShows(int movieId)
            {
                var shows = await _context.Showtimes
                    .Where(s => s.MovieId == movieId)
                    .ToListAsync();

                return Ok(shows);
            }

            [HttpPost]
            public async Task<IActionResult> AddShow(Showtime show)
            {
                _context.Showtimes.Add(show);
                await _context.SaveChangesAsync();
                return Ok(show);
            }
        }
    }
