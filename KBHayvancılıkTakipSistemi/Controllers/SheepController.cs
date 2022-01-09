using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KBHayvancılıkTakipSistemi.Models;
using KBHayvancılıkTakipSistemi.Response;
using System.Globalization;

namespace KBHayvancılıkTakipSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheepController : ControllerBase
    {
        private readonly FarmDBContext _context;

        public SheepController(FarmDBContext context)
        {
            _context = context;
        }

        // GET: api/Sheep
        [HttpGet]
        public IActionResult GetSheep()
        {


            var sheeps = _context.Sheep.Include(a => a.Race).Include(b => b.Group).OrderByDescending(x => x.DateOfBirth).ToList().
                Select(y => new SheepResponse()
                {


                    Id = y.Id,
                    BarcodeNo = y.BarcodeNo,
                    Gender = y.Gender,
                    DateOfBirth = y.DateOfBirth,
                    Age = DateTime.Now.Month,
                    Weight = y.Weight,
                    Race = new RaceResponse() { Id = y.Race.Id, Name = y.Race.Name },
                    Group = new GroupResponse() { Id = y.Group.Id, Name = y.Group.Name }
           
                  

                }) ;

            return Ok(sheeps);
        }

        // GET: api/Sheep/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sheep>> GetSheep(int id)
        {
            var sheep = await _context.Sheep.Include(i => i.Group).Include(k => k.Race).SingleOrDefaultAsync(c => c.Id == id);

            if (sheep == null)
            {
                return NotFound();
            }

            return sheep;
        }

        [HttpGet]

        [Route("GetSheepWithGroup/{groupId}")]
        public IActionResult GetSheepWithGroup(int groupId)
        {
            var sheeps = _context.Sheep.Include(x => x.Race).Include(y => y.Group).Where(z => z.GroupId == groupId).OrderByDescending(x => x.DateOfBirth).ToList().
                Select(y => new SheepResponse()
                {


                    Id = y.Id,
                    BarcodeNo = y.BarcodeNo,
                    Gender = y.Gender,
                    DateOfBirth = y.DateOfBirth,
                    Age = DateTime.Now.Month,
                    Weight = y.Weight,
                    Race = new RaceResponse() { Id = y.Race.Id, Name = y.Race.Name },
                    Group = new GroupResponse() { Id = y.Group.Id, Name = y.Group.Name },


                });

            return Ok(sheeps);
        
        }


        // PUT: api/Sheep/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSheep(int id, Sheep sheep)
        {
            if (id != sheep.Id)
            {
                return BadRequest();
            }

            _context.Entry(sheep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SheepExists(id))
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

        // POST: api/Sheep
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sheep>> PostSheep(Sheep sheep)
        {
            _context.Sheep.Add(sheep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSheep", new { id = sheep.Id }, sheep);
        }

        // DELETE: api/Sheep/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sheep>> DeleteSheep(int id)
        {
            var sheep = await _context.Sheep.FindAsync(id);
            if (sheep == null)
            {
                return NotFound();
            }

            _context.Sheep.Remove(sheep);
            await _context.SaveChangesAsync();

            return sheep;
        }

        private bool SheepExists(int id)
        {
            return _context.Sheep.Any(e => e.Id == id);
        }
    }
}
