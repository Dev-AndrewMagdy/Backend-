using TamayouzShared.Base;

namespace TamayouzAPI.Helper
{
    public class ResponseHelper
    {
        public static APIResponse<T> ResultResponse<T>(bool success, T? data, string? message = "")
        {
            return new APIResponse<T>
            {
                Success = success,
                Message = message,
                Data = data
            };
        }
    }
}
