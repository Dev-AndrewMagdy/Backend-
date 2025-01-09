using TamayouzShared.Base;
using TamayouzAPI.Data;
using TamayouzShared.Model.ConactUs;

namespace TamayouzAPI.Repository.Contact
{
    public class ConactUsRepository :Repository<ContactUs>, IContactUsRepository
    {
        public ConactUsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
