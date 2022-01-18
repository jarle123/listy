using Listy.DataAccess;
using Listy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Listy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListyListsController : ControllerBase
    {
        private readonly ListyDbContext _context;

        public ListyListsController(ListyDbContext context)
        {
            _context = context;
        }

        // GET: api/ListyLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListyList>>> GetListyLists()
        {
            var res = await _context.ListyLists
                .Include(p => p.ListItems)
                .ToListAsync();

            return res;
        }

        // GET: api/ListyLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListyList>> GetListyList(int id)
        {
            var listyList = await _context.ListyLists.FindAsync(id);

            if (listyList == null)
            {
                return NotFound();
            }

            listyList.ListItems = await _context.ListItems.Where(l => l.ListyListId == id).ToListAsync();

            return listyList;
        }

        // PUT: api/ListyLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListyList(int id, ListyList listyList)
        {
            if (id != listyList.ListyListId)
            {
                return BadRequest();
            }

            _context.Entry(listyList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListyListExists(id))
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

        // POST: api/ListyLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListyList>> PostListyList(ListyList listyList)
        {
            _context.ListyLists.Add(listyList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListyList", new { id = listyList.ListyListId }, listyList);
        }

        // DELETE: api/ListyLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListyList(int id)
        {
            var listyList = await _context.ListyLists.FindAsync(id);
            if (listyList == null)
            {
                return NotFound();
            }

            // Check for list items
            //             listyList.ListItems = await _context.ListItems.Where(l => l.ListyListId == id).ToListAsync();
            listyList.ListItems = await _context.ListItems.Where(l => l.ListyListId == id).ToListAsync();
            _context.ListItems.RemoveRange(listyList.ListItems);


            _context.ListyLists.Remove(listyList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListyListExists(int id)
        {
            return _context.ListyLists.Any(e => e.ListyListId == id);
        }
    }
}