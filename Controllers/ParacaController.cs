using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParacaApi.Models;

namespace ParacaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParacaController : ControllerBase
    {
        private readonly ParacaContext _context;

        public ParacaController(ParacaContext context)
        {
            _context = context;
        }

        // GET: api/Paraca
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paracaidista>>> GetPAracaidistas()
        {
            return await _context.PAracaidistas.ToListAsync();
        }

        // GET: api/Paraca/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paracaidista>> GetParacaidista(long id)
        {
            var paracaidista = await _context.PAracaidistas.FindAsync(id);

            if (paracaidista == null)
            {
                return NotFound();
            }

            return paracaidista;
        }

        // PUT: api/Paraca/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParacaidista(long id, Paracaidista paracaidista)
        {
            if (id != paracaidista.Id)
            {
                return BadRequest();
            }

            _context.Entry(paracaidista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParacaidistaExists(id))
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

        // POST: api/Paraca
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paracaidista>> PostParacaidista(Paracaidista paracaidista)
        {
            _context.PAracaidistas.Add(paracaidista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParacaidista", new { id = paracaidista.Id }, paracaidista);
        }

        // DELETE: api/Paraca/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParacaidista(long id)
        {
            var paracaidista = await _context.PAracaidistas.FindAsync(id);
            if (paracaidista == null)
            {
                return NotFound();
            }

            _context.PAracaidistas.Remove(paracaidista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParacaidistaExists(long id)
        {
            return _context.PAracaidistas.Any(e => e.Id == id);
        }
    }
}
