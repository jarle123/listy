using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Listy.DataAccess;
using Listy.Models;
using Microsoft.AspNetCore.Authorization;

namespace Listy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListItemsController : ControllerBase
    {
        private readonly ListyDbContext _context;

        public ListItemsController(ListyDbContext context)
        {
            _context = context;
        }

        // GET: api/ListItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListItem>>> GetListItems()
        {
            return await _context.ListItems.ToListAsync();
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("/testpost")]
        public async Task<ActionResult<IEnumerable<ListItem>>> TestGet()
        {
            return await _context.ListItems.ToListAsync();
        }

        // GET: api/ListItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListItem>> GetListItem(int id)
        {
            var listItem = await _context.ListItems.FindAsync(id);

            if (listItem == null)
            {
                return NotFound();
            }

            return listItem;
        }

        // PUT: api/ListItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListItem(int id, ListItem listItem)
        {
            if (id != listItem.ListItemId)
            {
                return BadRequest();
            }

            _context.Entry(listItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListItemExists(id))
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

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListItem>> PostListItem(ListItem listItem)
        {
            _context.ListItems.Add(listItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListItem", new { id = listItem.ListItemId }, listItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListItem(int id)
        {
            var listItem = await _context.ListItems.FindAsync(id);
            if (listItem == null)
            {
                return NotFound();
            }

            _context.ListItems.Remove(listItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListItemExists(int id)
        {
            return _context.ListItems.Any(e => e.ListItemId == id);
        }
    }
}
