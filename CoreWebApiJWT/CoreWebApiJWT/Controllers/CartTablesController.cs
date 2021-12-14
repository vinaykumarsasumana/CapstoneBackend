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
    public class CartTablesController : ControllerBase
    {
        private readonly DemoTokenContexts _context;

        public CartTablesController(DemoTokenContexts context)
        {
            _context = context;
        }

        //// GET: api/CartTables
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CartTable>>> GetCartTables()
        //{
        //    return await _context.CartTables.ToListAsync();
        //}

        //// GET: api/CartTables/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CartTable>> GetCartTable(int id)
        //{
        //    var cartTable = await _context.CartTables.FindAsync(id);

        //    if (cartTable == null)
        //    {
        //        return NotFound();
        //    }

        //    return cartTable;
        //}

        // PUT: api/CartTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartTable(int id, CartTable cartTable)
        {
            if (id != cartTable.CartId)
            {
                return BadRequest();
            }

            _context.Entry(cartTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartTableExists(id))
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

        // POST: api/CartTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CartTable>> PostCartTable(CartTable cartTable)
        //{
        //    _context.CartTables.Add(cartTable);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCartTable", new { id = cartTable.CartId }, cartTable);
        //}

        // DELETE: api/CartTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartTable(int id)
        {
            var cartTable = await _context.CartTables.FindAsync(id);
            if (cartTable == null)
            {
                return NotFound();
            }

            _context.CartTables.Remove(cartTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartTableExists(int id)
        {
            return _context.CartTables.Any(e => e.CartId == id);
        }
    }
}
