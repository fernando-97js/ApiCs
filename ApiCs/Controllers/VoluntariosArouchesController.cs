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
    public class VoluntariosAroucheController : ControllerBase {
        private readonly ApplicationDbContext _context;

        public VoluntariosAroucheController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: api/VoluntariosArouche
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntariosArouche>>> GetVoluntariosArouche() {
            return await _context.VoluntariosArouche.ToListAsync();
        }

        // GET: api/VoluntariosArouche/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VoluntariosArouche>> GetVoluntariosArouche(int id) {
            var voluntario = await _context.VoluntariosArouche.FindAsync(id);

            if (voluntario == null) {
                return NotFound();
            }

            return voluntario;
        }

        // PUT: api/VoluntariosArouche/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoluntariosArouche(int id, VoluntariosArouche voluntario) {
            if (id != voluntario.Id) {
                return BadRequest();
            }

            _context.Entry(voluntario).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!VoluntariosAroucheExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VoluntariosArouche
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VoluntariosArouche>> PostVoluntariosArouche([FromBody] VoluntariosArouche voluntario) {
            _context.VoluntariosArouche.Add(voluntario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoluntariosArouche", new { id = voluntario.Id }, voluntario);
        }

        // DELETE: api/VoluntariosArouche/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoluntariosArouche(int id) {
            var voluntario = await _context.VoluntariosArouche.FindAsync(id);
            if (voluntario == null) {
                return NotFound();
            }

            _context.VoluntariosArouche.Remove(voluntario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoluntariosAroucheExists(int id) {
            return _context.VoluntariosArouche.Any(e => e.Id == id);
        }
    }
}