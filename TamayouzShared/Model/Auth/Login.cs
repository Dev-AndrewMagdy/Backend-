using System.ComponentModel.DataAnnotations;

namespace TamayouzShared.Model.Auth
{
    public class Login
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
