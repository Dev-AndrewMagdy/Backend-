using Microsoft.AspNetCore.Mvc;
using TamayouzShared.Base;
using TamayouzAPI.Helper;
using TamayouzShared.Model.Auth;
using TamayouzAPI.Repository.Authentication;

namespace TamayouzAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> signup([FromBody] RegisterModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ResponseHelper.ResultResponse<string>(false , null, ModelState + "Invalid Data Form"));

                var result = await _authService.RegisterAsync(model);

                if (!result.IsAuthenticated)
                    return BadRequest(ResponseHelper.ResultResponse<string>(false, null, result.Message));


                return Ok(ResponseHelper.ResultResponse<AuthModel>(false, result, "User has been registered successfully"));
            }
            catch (Exception ex)
            {
                var errorResponse = ResponseHelper.ResultResponse<object>(false, null, ex.Message );
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<APIResponse<AuthModel>>> SignIn([FromBody] Login model)
        {
            try
            {
               /* if (!ModelState.IsValid)
                    return BadRequest(ResponseHelper.ResultResponse<string>(false, null, ModelState.ToString()));
*/
                var result = await _authService.GetTokenAsync(model);

                if (!result.IsAuthenticated)
                    return BadRequest(ResponseHelper.ResultResponse<AuthModel>(false, null, result.Message));

                return Ok(ResponseHelper.ResultResponse<AuthModel>(true, result, "User logged in successfully"));
            }
            catch (Exception ex)
            {
                var errorResponse = ResponseHelper.ResultResponse<object>(false, null, ex.Message);
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPost("addRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ResponseHelper.ResultResponse<string>(false, null, ModelState.ToString()));

                var result = await _authService.AddRoleAsync(model);

                if (!string.IsNullOrEmpty(result))
                    return BadRequest(ResponseHelper.ResultResponse<string>(false, null, result));

                return Ok(ResponseHelper.ResultResponse<AddRoleModel>(true, model, "User logged in successfully"));

            }
            catch (Exception ex)
            {
                var errorResponse = ResponseHelper.ResultResponse<object>(false, null, ex.Message);
                return StatusCode(500, errorResponse);
            }
        }
    }
}
