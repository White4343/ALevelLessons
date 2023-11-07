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
    public class CollarsController : ControllerBase
    {
        private readonly DataContext _context;

        public CollarsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Collars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collar>>> GetCollars()
        {
            var repo = new GenericRepository(_context);
            var models = await repo.GetAll<Collar>();

            return Ok(models);
        }

        // GET: api/Collars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Collar>> GetCollar(int id)
        {
            var repo = new GenericRepository(_context);
            var model = await repo.GetOne<Collar>(id);

            return Ok(model);
        }

        // PUT: api/Collars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollar(Collar collar)
        {
            var repo = new GenericRepository(_context);
            await repo.Update<Collar>(collar);

            return Ok();
        }

        // POST: api/Collars
        [HttpPost]
        public async Task<ActionResult<Collar>> PostCollar(Collar collar)
        {
            var repo = new GenericRepository(_context);
            await repo.Create<Collar>(collar);

            return Ok();
        }

        // DELETE: api/Collars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollar(int id)
        {
            if (_context.Collars == null)
            {
                return NotFound();
            }
            var collar = await GetCollar(id);
            if (collar == null)
            {
                return NotFound();
            }

            var repo = new GenericRepository(_context);
            await repo.Delete<Collar>(id);

            return NoContent();
        }
    }
}
