using TamayouzShared.Base;
using TamayouzAPI.Data;

namespace TamayouzAPI.Repository.RecentWork
{
    public class RecentWorkRepository : Repository<TamayouzShared.Model.RecentWorks.RecentWork> ,IRecentWorkRepository
    {
        public RecentWorkRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
