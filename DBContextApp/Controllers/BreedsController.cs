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
    public class BreedsController : ControllerBase
    {
        private readonly DataContext _context;

        public BreedsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Breeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breed>>> GetBreeds()
        {
            var repo = new GenericRepository(_context);
            var breeds = await repo.GetAll<Breed>();

            return Ok(breeds);
        }

        // GET: api/Breeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breed>> GetBreed(int id)
        {
            var repo = new GenericRepository(_context);
            var breed = await repo.GetOne<Breed>(id);

            return Ok(breed);
        }

        // PUT: api/Breeds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreed(Breed breed)
        {
            var repo = new GenericRepository(_context);
            await repo.Update<Breed>(breed);

            return Ok();
        }

        // POST: api/Breeds
        [HttpPost]
        public async Task<ActionResult<Breed>> PostBreed(Breed breed)
        {
            var repo = new GenericRepository(_context);
            await repo.Create<Breed>(breed);

            return Ok();
        }

        // DELETE: api/Breeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(int id)
        {
            if (_context.Breeds == null)
            {
                return NotFound();
            }
            var breed = await GetBreed(id);
            if (breed == null)
            {
                return NotFound();
            }

            var repo = new GenericRepository(_context);
            await repo.Delete<Breed>(id);

            return NoContent();
        }
    }
}
