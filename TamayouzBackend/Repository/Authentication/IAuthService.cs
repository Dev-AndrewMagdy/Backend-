using TamayouzShared.Model.Auth;

namespace TamayouzAPI.Repository.Authentication
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(Login model);
        Task<string> AddRoleAsync(AddRoleModel model);

    }
}
