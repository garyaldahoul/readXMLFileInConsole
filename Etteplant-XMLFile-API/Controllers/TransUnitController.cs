using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Etteplant_XMLFile_API.Data;


namespace Etteplant_XMLFile_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransUnitController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TransUnitController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/TransUnit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.TransUnit>>> GetTransUnits()
        {
          if (_context.TransUnits == null)
          {
              return NotFound();
          }
            return await _context.TransUnits.ToListAsync();
        }

        // GET: api/TransUnit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.TransUnit>> GetTransUnit(int id)
        {
          if (_context.TransUnits == null)
          {
              return NotFound();
          }
            var transUnit = await _context.TransUnits.FindAsync(id);

            if (transUnit == null)
            {
                return NotFound();
            }

            return transUnit;
        }

        // PUT: api/TransUnit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransUnit(int id, Models.TransUnit transUnit)
        {
            if (id != transUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(transUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransUnitExists(id))
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

        // POST: api/TransUnit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.TransUnit>> PostTransUnit(Models.TransUnit transUnit)
        {
          if (_context.TransUnits == null)
          {
              return Problem("Entity set 'ApplicationDBContext.TransUnits'  is null.");
          }
            _context.TransUnits.Add(transUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransUnit", new { id = transUnit.Id }, transUnit);
        }

        // DELETE: api/TransUnit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransUnit(int id)
        {
            if (_context.TransUnits == null)
            {
                return NotFound();
            }
            var transUnit = await _context.TransUnits.FindAsync(id);
            if (transUnit == null)
            {
                return NotFound();
            }

            _context.TransUnits.Remove(transUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransUnitExists(int id)
        {
            return (_context.TransUnits?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
    
}
