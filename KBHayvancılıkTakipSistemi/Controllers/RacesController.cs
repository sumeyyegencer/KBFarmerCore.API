using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KBHayvancılıkTakipSistemi.Models;
using KBHayvancılıkTakipSistemi.Response;

namespace KBHayvancılıkTakipSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {
        private readonly FarmDBContext _context;

        public RacesController(FarmDBContext context)
        {
            _context = context;
        }

        // GET: api/Races
        [HttpGet]
        public IActionResult GetRace()
        {
            var races = _context.Race.ToList().Select(x => new RaceResponse()
            {

                Id = x.Id,
                Name = x.Name


            });

            return Ok(races);
        }

        // GET: api/Races/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> GetRace(int id)
        {
            var race = await _context.Race.FindAsync(id);

            if (race == null)
            {
                return NotFound();
            }

            return race;
        }

        // PUT: api/Races/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(int id, Race race)
        {
            if (id != race.Id)
            {
                return BadRequest();
            }

            _context.Entry(race).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Races
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Race>> PostRace(Race race)
        {
            _context.Race.Add(race);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRace", new { id = race.Id }, race);
        }

        // DELETE: api/Races/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Race>> DeleteRace(int id)
        {
            var race = await _context.Race.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }

            _context.Race.Remove(race);
            await _context.SaveChangesAsync();

            return race;
        }

        private bool RaceExists(int id)
        {
            return _context.Race.Any(e => e.Id == id);
        }
    }
}
