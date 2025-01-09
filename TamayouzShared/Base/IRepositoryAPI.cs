using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamayouzShared.Base
{
    public interface IRepositoryAPI<T> where T : class
    {

        Task<APIResponse<T>?> GetAsync<T>(string uri);
        Task<APIResponse<T>?> PostAsync<T>(string uri, HttpContent value);
        Task<APIResponse<T>?> UpdateAsync<T>(string uri, HttpContent value);
        Task<APIResponse<T>?> DeleteAsync<T>(string uri, int id);
    }
    
}
