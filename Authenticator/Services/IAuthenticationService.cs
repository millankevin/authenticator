using Authenticator.Common;
using Authenticator.DTO;

namespace Authenticator.Services
{
    public interface IAuthenticationService
    {
        Task<Message> GetTokenAsync(LoginDto model);
    }
}
