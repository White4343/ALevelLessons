using System.Collections;
using DBContextApp.Context;
using DBContextApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DBContextApp.Repository
{
    public class PetRepository : GenericRepository, IPageFilter
    {
        public PetRepository(DataContext dbContext) : base(dbContext)
        {
        }


        public async Task<IEnumerable<T>> GetPagesByFilters<T>(int page, int pageSize, int? minAge, int? maxAge, string name, bool descendingOrder) where T : class
        {
            IQueryable<Pet> query = _dbContext.Set<Pet>();

            if (minAge.HasValue)
            {
                query = query.Where(p => p.Age >= minAge.Value);
            }

            if (maxAge.HasValue)
            {
                query = query.Where(p => p.Age <= maxAge.Value);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            query = descendingOrder ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name);

            return (IEnumerable<T>)await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
