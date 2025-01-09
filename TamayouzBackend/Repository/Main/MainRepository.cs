using Microsoft.EntityFrameworkCore;
using TamayouzShared.Base;
using TamayouzAPI.Data;
using TamayouzShared.Model.Home;

namespace TamayouzAPI.Repository.Main
{
    public class MainRepository : Repository<Home> , IMainRepository
    {
        public MainRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
  
        public async Task<Home?> GetHomeAsync()
        {
            return await _dbSet
                .Include(h => h.ServiceCategoty)
                .Include(h => h.RecentWorks)
                .Include(h => h.Team)
                .Include(h => h.Blog)
                .Include(h => h.FAQ)
                .Include(h => h.About)
                .SingleOrDefaultAsync(h => h.ID == 1);
        }
    }
}
