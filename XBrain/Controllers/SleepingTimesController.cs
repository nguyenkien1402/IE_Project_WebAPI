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
    public class SleepingTimesController : Controller
    {
        private readonly XBrainContext _context;

        public SleepingTimesController(XBrainContext context)
        {
            _context = context;
        }

        // GET: api/SleepingTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SleepingTime>>> GetSleepingTime()
        {
            return await _context.SleepingTime.ToListAsync();
        }

        // GET: api/SleepingTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SleepingTime>> GetSleepingTime(int id)
        {
            var sleepingTime = await _context.SleepingTime.FindAsync(id);

            if (sleepingTime == null)
            {
                return NotFound();
            }

            return sleepingTime;
        }

        // PUT: api/SleepingTimes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSleepingTime(int id, SleepingTime sleepingTime)
        {
            if (id != sleepingTime.Id)
            {
                return BadRequest();
            }

            _context.Entry(sleepingTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SleepingTimeExists(id))
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

        // POST: api/SleepingTimes
        [HttpPost]
        public async Task<ActionResult<SleepingTime>> PostSleepingTime(SleepingTime sleepingTime)
        {
            _context.SleepingTime.Add(sleepingTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSleepingTime", new { id = sleepingTime.Id }, sleepingTime);
        }

        // DELETE: api/SleepingTimes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SleepingTime>> DeleteSleepingTime(int id)
        {
            var sleepingTime = await _context.SleepingTime.FindAsync(id);
            if (sleepingTime == null)
            {
                return NotFound();
            }

            _context.SleepingTime.Remove(sleepingTime);
            await _context.SaveChangesAsync();

            return sleepingTime;
        }

        private bool SleepingTimeExists(int id)
        {
            return _context.SleepingTime.Any(e => e.Id == id);
        }
    }
}
