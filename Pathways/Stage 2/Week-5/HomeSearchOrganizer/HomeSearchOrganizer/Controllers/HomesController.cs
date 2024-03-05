using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeSearchOrganizer.Models;

namespace HomeSearchOrganizer.Controllers
{
    [Route("api/Homes")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly HomeContext _context;

        public HomesController(HomeContext context)
        {
            _context = context;
        }

        // GET: api/Homes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeDto>>> GetHomes()
        {
            return await _context.Home
                  .Select(x => HomeToDto(x))
                  .ToListAsync();
        }

        // GET: api/Homes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeDto>> GetHome(long id)
        {
            var home = await _context.Home.FindAsync(id);

            if (home == null)
            {
                return NotFound();
            }

            return HomeToDto(home);
        }

        // PUT: api/Homes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(long id, HomeDto homeDto)
        {
            if (id != homeDto.Id)
            {
                return BadRequest();
            }

            var home = await _context.Home.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }

            home.Address = homeDto.Address;
            home.IsComplete = homeDto.IsComplete;
            home.Bedrooms = homeDto.Bedrooms;
            home.Bathrooms = homeDto.Bathrooms;
            home.SquareFootage = homeDto.SquareFootage;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!HomeExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Homes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HomeDto>> PostHome(HomeDto homeDto)
        {
            var home = new Home
            {
                IsComplete = homeDto.IsComplete,
                Address = homeDto.Address,
                Bedrooms = homeDto.Bedrooms,
                Bathrooms = homeDto.Bathrooms,
                SquareFootage = homeDto.SquareFootage
            };

            _context.Home.Add(home);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetHome),
                new { id = home.Id },
                HomeToDto(home));
        }

        // DELETE: api/Homes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHome(long id)
        {
            var home = await _context.Home.FindAsync(id);

            if (home == null)
            {
                return NotFound();
            }

            _context.Home.Remove(home);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeExists(long id)
        {
            return (_context.Home?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private static HomeDto HomeToDto(Home home) =>
            new HomeDto
            {
                Id = home.Id,
                Address = home.Address,
                IsComplete = home.IsComplete,
                Bedrooms = home.Bedrooms,
                Bathrooms = home.Bathrooms,
                SquareFootage = home.SquareFootage
            };
    }
}
