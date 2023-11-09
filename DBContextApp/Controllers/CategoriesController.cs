using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContextApp.Context;
using DBContextApp.Models;
using DBContextApp.Repository;

namespace DBContextApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var repo = new GenericRepository(_context);
            var categories = await repo.GetAll<Category>();

            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var repo = new GenericRepository(_context);
            var category = await repo.GetOne<Category>(id);

            return Ok(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Category category)
        {
            var repo = new GenericRepository(_context);
            await repo.Update<Category>(category);
            
            return Ok();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var repo = new GenericRepository(_context);
            await repo.Create<Category>(category);

            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            var repo = new GenericRepository(_context);
            await repo.Delete<Category>(id);

            return NoContent();
        }
    }
}
