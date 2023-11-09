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
    public class LocationsController : ControllerBase
    {
        private readonly DataContext _context;

        public LocationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var repo = new GenericRepository(_context);
            var models = await repo.GetAll<Location>();

            return Ok(models);
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var repo = new GenericRepository(_context);
            var model = await repo.GetOne<Location>(id);

            return Ok(model);
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(Location location)
        {
            var repo = new GenericRepository(_context);
            await repo.Update<Location>(location);

            return Ok();
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            var repo = new GenericRepository(_context);
            await repo.Create<Location>(location);

            return Ok();
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (_context.Locations == null)
            {
                return NotFound();
            }
            var location = await GetLocation(id);
            if (location == null)
            {
                return NotFound();
            }

            var repo = new GenericRepository(_context);
            await repo.Delete<Location>(id);

            return NoContent();
        }
    }
}
