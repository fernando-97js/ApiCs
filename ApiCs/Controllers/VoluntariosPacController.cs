using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCs;

namespace ApiCs.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VoluntariosPacController : ControllerBase {
        private readonly ApplicationDbContext _context;

        public VoluntariosPacController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: api/VoluntariosPac
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntariosPac>>> GetVoluntariosPac() {
            return await _context.VoluntariosPac.ToListAsync();
        }

        // GET: api/VoluntariosPac/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VoluntariosPac>> GetVoluntariosPac(int id) {
            var voluntario = await _context.VoluntariosPac.FindAsync(id);

            if (voluntario == null) {
                return NotFound();
            }

            return voluntario;
        }

        // PUT: api/VoluntariosPac/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoluntariosPac(int id, VoluntariosPac voluntario) {
            if (id != voluntario.Id) {
                return BadRequest();
            }

            _context.Entry(voluntario).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!VoluntariosPacExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VoluntariosPac
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VoluntariosPac>> PostVoluntariosPac([FromBody] VoluntariosPac voluntario) {
            _context.VoluntariosPac.Add(voluntario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoluntariosPac", new { id = voluntario.Id }, voluntario);
        }

        // DELETE: api/VoluntariosPac/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoluntariosPac(int id) {
            var voluntario = await _context.VoluntariosPac.FindAsync(id);
            if (voluntario == null) {
                return NotFound();
            }

            _context.VoluntariosPac.Remove(voluntario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoluntariosPacExists(int id) {
            return _context.VoluntariosPac.Any(e => e.Id == id);
        }
    }
}
