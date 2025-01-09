using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TamayouzShared.Base;

namespace TamayouzAPI.Helper
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new APIResponse<object>
            {
                Success = false,
                Message = context.Exception.Message,
                Data = null
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

}
