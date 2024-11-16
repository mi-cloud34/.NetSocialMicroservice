using Social.AuthApi.Models;

namespace Social.AuthApi.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Users applicationUser
            //IEnumerable<string> roles

            );
    }
}