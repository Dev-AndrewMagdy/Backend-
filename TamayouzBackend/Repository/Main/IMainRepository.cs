using TamayouzShared.Base;
using TamayouzShared.Model.Home;

namespace TamayouzAPI.Repository.Main
{
    public interface IMainRepository : IRepository<Home>
    {
        Task<Home?> GetHomeAsync();
    }
}
