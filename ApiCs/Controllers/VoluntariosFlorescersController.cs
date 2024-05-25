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
    public class VoluntariosFlorescerController : ControllerBase {
        private readonly ApplicationDbContext _context;

        public VoluntariosFlorescerController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: api/VoluntariosFlorescer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntariosFlorescer>>> GetVoluntariosFlorescer() {
            return await _context.VoluntariosFlorescer.ToListAsync();
        }

        // GET: api/VoluntariosFlorescer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VoluntariosFlorescer>> GetVoluntariosFlorescer(int id) {
            var voluntario = await _context.VoluntariosFlorescer.FindAsync(id);

            if (voluntario == null) {
                return NotFound();
            }

            return voluntario;
        }

        // PUT: api/VoluntariosFlorescer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoluntariosFlorescer(int id, VoluntariosFlorescer voluntario) {
            if (id != voluntario.Id) {
                return BadRequest();
            }

            _context.Entry(voluntario).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!VoluntariosFlorescerExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VoluntariosFlorescer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VoluntariosFlorescer>> PostVoluntariosFlorescer([FromBody] VoluntariosFlorescer voluntario) {
            _context.VoluntariosFlorescer.Add(voluntario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoluntariosFlorescer", new { id = voluntario.Id }, voluntario);
        }

        // DELETE: api/VoluntariosFlorescer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoluntariosFlorescer(int id) {
            var voluntario = await _context.VoluntariosFlorescer.FindAsync(id);
            if (voluntario == null) {
                return NotFound();
            }

            _context.VoluntariosFlorescer.Remove(voluntario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoluntariosFlorescerExists(int id) {
            return _context.VoluntariosFlorescer.Any(e => e.Id == id);
        }
    }
}