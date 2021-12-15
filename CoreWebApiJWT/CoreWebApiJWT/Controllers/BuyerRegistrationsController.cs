using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreWebApiJWT.DataContexts;

namespace CoreWebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerRegistrationsController : ControllerBase
    {
        private readonly DemoTokenContexts _context;

        public BuyerRegistrationsController(DemoTokenContexts context)
        {
            _context = context;
        }

        // GET: api/BuyerRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerRegistration>>> GetBuyerRegistrations()
        {
            return await _context.BuyerRegistrations.ToListAsync();
        }

        // GET: api/BuyerRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerRegistration>> GetBuyerRegistration(int id)
        {
            var buyerRegistration = await _context.BuyerRegistrations.FindAsync(id);

            if (buyerRegistration == null)
            {
                return NotFound();
            }

            return buyerRegistration;
        }

        // PUT: api/BuyerRegistrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyerRegistration(int id, BuyerRegistration buyerRegistration)
        {
            if (id != buyerRegistration.BuyerRegId)
            {
                return BadRequest();
            }

            _context.Entry(buyerRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerRegistrationExists(id))
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

        // POST: api/BuyerRegistrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuyerRegistration>> PostBuyerRegistration(BuyerRegistration buyerRegistration)
        {
            _context.BuyerRegistrations.Add(buyerRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuyerRegistration", new { id = buyerRegistration.BuyerRegId }, buyerRegistration);
        }

        // DELETE: api/BuyerRegistrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyerRegistration(int id)
        {
            var buyerRegistration = await _context.BuyerRegistrations.FindAsync(id);
            if (buyerRegistration == null)
            {
                return NotFound();
            }

            _context.BuyerRegistrations.Remove(buyerRegistration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuyerRegistrationExists(int id)
        {
            return _context.BuyerRegistrations.Any(e => e.BuyerRegId == id);
        }

    }
}
