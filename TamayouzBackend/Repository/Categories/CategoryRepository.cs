using TamayouzShared.Base;
using TamayouzAPI.Data;
using TamayouzShared.Model.ServicesCategory;

namespace TamayouzAPI.Repository.Categories
{
    public class CategoryRepository : Repository<ServiceCategoty>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    }
}
