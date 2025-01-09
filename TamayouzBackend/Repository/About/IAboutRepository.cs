using TamayouzShared.Base;
using TamayouzShared.Model.AboutUs;

namespace TamayouzAPI.Repository
{
    public interface IAboutRepository : IRepository<About>{

        Task<About> GetAbout();
    }
}
