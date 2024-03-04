using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<HomeDTO>>> GetHomes()
        {
            return await _context.Home
                  .Select(x => HomeToDTO(x))
                  .ToListAsync();
        }

        // GET: api/Homes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeDTO>> GetHome(long id)
        {
            var home = await _context.Home.FindAsync(id);

            if (home == null)
            {
                return NotFound();
            }

            return HomeToDTO(home);
        }

        // PUT: api/Homes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(long id, HomeDTO homeDTO)
        {
            if (id != homeDTO.Id)
            {
                return BadRequest();
            }

            var home = await _context.Home.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }

            home.Name = homeDTO.Name;
            home.IsComplete = homeDTO.IsComplete;

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
        public async Task<ActionResult<HomeDTO>> PostHome(HomeDTO homeDTO)
        {
            var home = new Home
            {
                IsComplete = homeDTO.IsComplete,
                Name = homeDTO.Name
            };

            _context.Home.Add(home);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetHome),
                new { id = home.Id },
                HomeToDTO(home));
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
        private static HomeDTO HomeToDTO(Home home) =>
            new HomeDTO
            {
                Id = home.Id,
                Name = home.Name,
                IsComplete = home.IsComplete
            };
    }
}
