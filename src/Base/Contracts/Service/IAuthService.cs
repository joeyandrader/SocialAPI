using RedeSocialAPI.Models.Data;
using RedeSocialAPI.Models.Request;
using RedeSocialAPI.Models.Response;

namespace RedeSocialAPI.src.Base.Contracts.Service
{
    public interface IAuthService
    {
        Task<AuthResponse> Auth(AuthRequest request);
    }
}
