using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamayouzShared.APIHttpClient;

namespace TamayouzShared.Base
{
    public class RepositoryAPI<T> : IRepositoryAPI<T> where T : class
    {
        APIClient apiClient;
        public RepositoryAPI(APIClient _apiClient)
        {
            apiClient = _apiClient;
        }

        public async Task<APIResponse<T1>?> DeleteAsync<T1>(string uri, int id)
        {
            return await apiClient.Delete<T1>(uri, id);
        }

        public async Task<APIResponse<T1?>?> GetAsync<T1>(string uri)
        {
            return await apiClient.Get<T1?>(uri);
        }

        public async Task<APIResponse<T1?>?> PostAsync<T1>(string uri, HttpContent value)
        {
            return await apiClient.Post<T1?>(uri, value);
        }

        public async Task<APIResponse<T1?>?> UpdateAsync<T1>(string uri, HttpContent value)
        {
            return await apiClient.Update<T1?>(uri, value);
        }
    }

}
