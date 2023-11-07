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
    public class PetsController : ControllerBase
    {
        private readonly DataContext _context;

        public PetsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            var repo = new GenericRepository(_context);
            var models = await repo.GetAll<Pet>();

            return Ok(models);
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var repo = new GenericRepository(_context);
            var models = await repo.GetOne<Pet>(id);

            return Ok(models);
        }

        // PUT: api/Pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(Pet pet)
        {
            var repo = new GenericRepository(_context);
            await repo.Update<Pet>(pet);

            return Ok();
        }
        
        // POST: api/Pets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            var repo = new GenericRepository(_context);
            await repo.Create<Pet>(pet);

            return Ok();
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            if (_context.Pets == null)
            {
                return NotFound();
            }
            var pet = await GetPet(id);
            if (pet == null)
            {
                return NotFound();
            }
            var repo = new GenericRepository(_context);
            await repo.Delete<Pet>(id);

            return NoContent();
        }
    }
}