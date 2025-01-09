using Microsoft.EntityFrameworkCore;
using Model.Services;
using TamayouzShared.Base;
using TamayouzAPI.Data;
using TamayouzAPI.Repository.Services;

namespace TamayouzAPI.Repository.Authentication
{
    public class ServicesRepository : Repository<Service>, IServicesRepository
    {
        public ServicesRepository(ApplicationDbContext dbContext) : base(dbContext) {}

        public async Task<IEnumerable<Service>> getByCategory(int categoryId)
        {
            return await _dbSet.Where(p => p.Category.ID == categoryId).ToListAsync();
        }

    }
 
}