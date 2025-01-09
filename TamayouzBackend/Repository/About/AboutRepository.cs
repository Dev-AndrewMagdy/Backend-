using Microsoft.EntityFrameworkCore;
using TamayouzShared.Base;
using TamayouzShared.Model.AboutUs;
using TamayouzAPI.Data;

namespace TamayouzAPI.Repository
{
    public class AboutRepository : Repository<About> , IAboutRepository
    {
        public AboutRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {}

        public async Task<About> GetAbout() => await _dbSet.Include(a => a.SocialLinks)
            .SingleOrDefaultAsync(a => a.ID == 1);
    }
}
