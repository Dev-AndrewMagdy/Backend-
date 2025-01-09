using Microsoft.AspNetCore.Http;

namespace TamayouzAPI.Helper
{
    public static class JWTC
    {
        public const string Key = "sz8eI7OdHBrjrIo8j9nTW/rQyO1OvY0pAQ2wDKQZw/0=";
        public const string Issuer = "SecureApi";
        public const string Audience = "SecureApiUser";
        public const double DurationInDays = 30;
    }
}
