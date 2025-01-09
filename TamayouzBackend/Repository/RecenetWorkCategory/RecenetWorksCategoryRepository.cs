using TamayouzShared.Base;
using TamayouzAPI.Data;
using TamayouzShared.Model.RecentWorkCategory;

namespace TamayouzAPI.Repository.RecenetWorkCategory
{
    public class RecenetWorksCategoryRepository :Repository<RecentWorkCategory> , IRecenetWorksCategoryRepository
    {
        public RecenetWorksCategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
