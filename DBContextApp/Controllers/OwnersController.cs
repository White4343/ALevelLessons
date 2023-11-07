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
using System.Drawing;

namespace DBContextApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Owners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetOwners()
        {
            var repo = new GenericRepository(_context);
            var models = await repo.GetAll<Owner>();

            return Ok(models);
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
            var repo = new GenericRepository(_context);
            var models = await repo.GetOne<Owner>(id);

            return Ok(models);
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(Owner owner)
        {
            var repo = new GenericRepository(_context);
            await repo.Update<Owner>(owner);

            return Ok();
        }

        // POST: api/Owners
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            var repo = new GenericRepository(_context);
            await repo.Create<Owner>(owner);

            return Ok();
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            if (_context.Owners == null)
            {
                return NotFound();
            }
            var owner = await GetOwner(id);
            if (owner == null)
            {
                return NotFound();
            }

            var repo = new GenericRepository(_context);
            await repo.Delete<Owner>(id);

            return NoContent();
        }
    }
}
