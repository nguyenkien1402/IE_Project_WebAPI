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
    public class DailyActivitiesController : ControllerBase
    {
        private readonly XBrainContext _context;

        public DailyActivitiesController(XBrainContext context)
        {
            _context = context;
        }


        [HttpGet("byuser")]
        public ActionResult<IEnumerable<DailyActivity>> GetDailyActivityByUserIdAndDate(int id, String date)
        {
            DateTime dt = DateTime.Parse(date);
            return _context.DailyActivity.Where(p => p.UserId == id && p.DateAchieve == dt).ToList();
        }


        // GET: api/DailyActivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyActivity>>> GetDailyActivity()
        {
            return await _context.DailyActivity.ToListAsync();
        }

        // GET: api/DailyActivities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyActivity>> GetDailyActivity(int id)
        {
            var dailyActivity = await _context.DailyActivity.FindAsync(id);

            if (dailyActivity == null)
            {
                return NotFound();
            }

            return dailyActivity;
        }

        // PUT: api/DailyActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyActivity(int id, DailyActivity dailyActivity)
        {
            if (id != dailyActivity.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyActivityExists(id))
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

        // POST: api/DailyActivities
        [HttpPost]
        public async Task<ActionResult<DailyActivity>> PostDailyActivity(DailyActivity dailyActivity)
        {
            _context.DailyActivity.Add(dailyActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyActivity", new { id = dailyActivity.Id }, dailyActivity);
        }

        // DELETE: api/DailyActivities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyActivity>> DeleteDailyActivity(int id)
        {
            var dailyActivity = await _context.DailyActivity.FindAsync(id);
            if (dailyActivity == null)
            {
                return NotFound();
            }

            _context.DailyActivity.Remove(dailyActivity);
            await _context.SaveChangesAsync();

            return dailyActivity;
        }

        private bool DailyActivityExists(int id)
        {
            return _context.DailyActivity.Any(e => e.Id == id);
        }
    }
}
