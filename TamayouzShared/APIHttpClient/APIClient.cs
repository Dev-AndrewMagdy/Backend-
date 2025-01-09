using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using TamayouzShared.Base;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TamayouzShared.APIHttpClient
{
    public class APIClient
    {
        private HttpClient _httpClient;
        //private ILocalStorageService _localStorageService;

        public APIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // _localStorageService = localStorageService;
        }

        public async Task<APIResponse<T?>> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await sendRequest<T?>(request);
        }

        public async Task<APIResponse<T?>?> Post<T>(string uri, HttpContent value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            //  var response = await _httpClient.PostAsync(uri, value);
            return await sendRequest<T?>(request);
        }

        public async Task<APIResponse<T>?> Delete<T>(string uri, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, uri + $"/{id}");
            return await sendRequest<T>(request);
        }
        public async Task<APIResponse<T>?> Update<T>(string uri, HttpContent value)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Headers.Add("accept", "application/json");

            request.Content = value;
            /*
            string jsonData =  JsonSerializer.Serialize(value);
            Debug.WriteLine("request =: " + jsonData);

            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            if (formFile != null)
            {
                Debug.WriteLine("Update =: formFile not null");


                var content = new MultipartFormDataContent();
                if (value != null)
                {
                    // Serialize the value and add it as a JSON part
                    var jsonContent = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
                    content.Add(jsonContent, "value");


                }
                var fileStream = formFile.OpenReadStream();
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(formFile.ContentType);
                content.Add(fileContent, "formFile", formFile.Name);
                request.Content = content;
            }
            else
            {
                Debug.WriteLine("Update =: form file null");

                // Handle the case where there's no file but JSON value is provided
                if (value != null)
                {
                    request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");


                }
                else
                {
                    // Handle case where neither file nor JSON value is provided (optional)
                    return default; // or throw an exception, depending on your requirements
                }
            }
            */
            return await sendRequest<T>(request);
        }

        private async Task<APIResponse<T>?> sendRequest<T>(HttpRequestMessage request)
        {
            try
            {
                var token = getToken();
                bool isApiUrl = !request.RequestUri.IsAbsoluteUri;
                if (token != null && isApiUrl)
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using var response = await _httpClient.SendAsync(request);

                APIResponse<T>? data = await response.Content.ReadFromJsonAsync<APIResponse<T>>();
                return data;

            }
            catch (HttpRequestException e)
            {
                return new APIResponse<T> { Success = false, Message = e.Message };
            }
            catch (Exception ex)
            {
                return new APIResponse<T> { Success = false, Message = ex.Message };
            }
        }

        private string getToken()
        {
            return string.Empty;
        }
    }

}
