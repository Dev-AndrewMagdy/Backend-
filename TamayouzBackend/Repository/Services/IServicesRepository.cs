using Model.Services;
using TamayouzShared.Base;

namespace TamayouzAPI.Repository.Services
{
    public interface IServicesRepository : IRepository<Service>
    {
        Task<IEnumerable<Service>> getByCategory(int categoryId);
    }
}
