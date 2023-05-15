using CustomAPI.Models;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesContext _db;

        //private readonly ILogger<CategoriesController> _logger;

        //po co ten logger, kiedy go u¿ywaæ?
        //public CategoriesController(ILogger<CategoriesController> logger)
        //{
        //    _logger = logger;
        //}

        public CategoriesController(CategoriesContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetFirstFiveCategories")]
        public async Task<ActionResult<IEnumerable<Categories>>> GetFirstFive()
        {
            return await _db.Categories.OrderByDescending(x => x.Id).Take(10).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetItemById(int id)
        {
            var Item = await _db.Categories.FindAsync(id);

            if (Item == null)
            {
                return NotFound();
            }

            return Item;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Categories>>> PostCategoriesItem(Categories item)
        {
            _db.Categories.Add(item);
            await _db.SaveChangesAsync();
            
            //Po co CreatedAtAction, jak dzia³a?
            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriesItem(int id)
        {
            var Item = await _db.Categories.FindAsync(id);
            if (Item == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(Item);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}