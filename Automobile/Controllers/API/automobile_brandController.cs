using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Automobile.Data;
using Automobile.Models;

namespace Automobile.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class automobile_brandController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public automobile_brandController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/automobile_brand
        [HttpGet]
        public async Task<ActionResult<IEnumerable<automobile_brand>>> Getautomobile_brands()
        {
            return await _context.automobile_brands.Include(t => t.products).ToListAsync();
        }

        // GET: api/automobile_brand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<automobile_brand>> Getautomobile_brand(int id)
        {
            var automobile_brand = await _context.automobile_brands.FindAsync(id);

            if (automobile_brand == null)
            {
                return NotFound();
            }

            return automobile_brand;
        }

        // PUT: api/automobile_brand/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putautomobile_brand(int id, automobile_brand automobile_brand)
        {
            if (id != automobile_brand.automobile_brandId)
            {
                return BadRequest();
            }

            _context.Entry(automobile_brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!automobile_brandExists(id))
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

        // POST: api/automobile_brand
        [HttpPost]
        public async Task<ActionResult<automobile_brand>> Postautomobile_brand(automobile_brand automobile_brand)
        {
            _context.automobile_brands.Add(automobile_brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getautomobile_brand", new { id = automobile_brand.automobile_brandId }, automobile_brand);
        }

        // DELETE: api/automobile_brand/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<automobile_brand>> Deleteautomobile_brand(int id)
        {
            var automobile_brand = await _context.automobile_brands.FindAsync(id);
            if (automobile_brand == null)
            {
                return NotFound();
            }

            _context.automobile_brands.Remove(automobile_brand);
            await _context.SaveChangesAsync();

            return automobile_brand;
        }

        private bool automobile_brandExists(int id)
        {
            return _context.automobile_brands.Any(e => e.automobile_brandId == id);
        }
    }
}
