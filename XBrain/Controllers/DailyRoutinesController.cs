using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XBrain.Models;

namespace XBrain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyRoutinesController : ControllerBase
    {
        private readonly XBrainContext _context;

        public DailyRoutinesController(XBrainContext context)
        {
            _context = context;
        }

        // GET: api/DailyRoutines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyRoutine>>> GetDailyRoutine()
        {
            Console.WriteLine("get all");
            return await _context.DailyRoutine.ToListAsync();
        }

        // GET: api/DailyRoutines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyRoutine>> GetDailyRoutine(int id)
        {
            var dailyRoutine = await _context.DailyRoutine.FindAsync(id);

            if (dailyRoutine == null)
            {
                return NotFound();
            }

            return dailyRoutine;
        }

        // PUT: api/DailyRoutines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyRoutine(int id, DailyRoutine dailyRoutine)
        {
            if (id != dailyRoutine.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyRoutine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyRoutineExists(id))
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

        // POST: api/DailyRoutines
        [HttpPost]
        public async Task<ActionResult<DailyRoutine>> PostDailyRoutine(int userId, DailyRoutine dailyRoutine)
        {
            Console.WriteLine("Go for it:"+userId);
            dailyRoutine.UserId = userId;
            _context.DailyRoutine.Add(dailyRoutine);
            await _context.SaveChangesAsync();
            Console.WriteLine("Insert Ok");

            return CreatedAtAction("GetDailyRoutine", new { id = dailyRoutine.Id }, dailyRoutine);
        }

        // DELETE: api/DailyRoutines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyRoutine>> DeleteDailyRoutine(int id)
        {
            var dailyRoutine = await _context.DailyRoutine.FindAsync(id);
            if (dailyRoutine == null)
            {
                return NotFound();
            }

            _context.DailyRoutine.Remove(dailyRoutine);
            await _context.SaveChangesAsync();

            return dailyRoutine;
        }

        private bool DailyRoutineExists(int id)
        {
            return _context.DailyRoutine.Any(e => e.Id == id);
        }
    }
}
