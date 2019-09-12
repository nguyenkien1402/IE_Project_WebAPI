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
    public class XbrainUsersController : ControllerBase
    {
        private readonly XBrainContext _context;

        public XbrainUsersController(XBrainContext context)
        {
            _context = context;
        }

        // GET: api/XbrainUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<XbrainUser>>> GetXbrainUser()
        {
            return await _context.XbrainUser.ToListAsync();
        }

        // GET: api/XbrainUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<XbrainUser>> GetXbrainUser(int id)
        {
            var xbrainUser = await _context.XbrainUser.FindAsync(id);

            if (xbrainUser == null)
            {
                return NotFound();
            }

            return xbrainUser;
        }

        // PUT: api/XbrainUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXbrainUser(int id, XbrainUser xbrainUser)
        {
            if (id != xbrainUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(xbrainUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XbrainUserExists(id))
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

        // POST: api/XbrainUsers
        [HttpPost]
        public async Task<ActionResult<XbrainUser>> PostXbrainUser(XbrainUser xbrainUser)
        {
            _context.XbrainUser.Add(xbrainUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXbrainUser", new { id = xbrainUser.Id }, xbrainUser);
        }

        // DELETE: api/XbrainUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<XbrainUser>> DeleteXbrainUser(int id)
        {
            var xbrainUser = await _context.XbrainUser.FindAsync(id);
            if (xbrainUser == null)
            {
                return NotFound();
            }

            _context.XbrainUser.Remove(xbrainUser);
            await _context.SaveChangesAsync();

            return xbrainUser;
        }

        private bool XbrainUserExists(int id)
        {
            return _context.XbrainUser.Any(e => e.Id == id);
        }
    }
}
