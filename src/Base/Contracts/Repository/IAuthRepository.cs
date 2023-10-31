using RedeSocialAPI.Models.Data;
using RedeSocialAPI.Models.Request;

namespace RedeSocialAPI.src.Base.Contracts.Repository
{
    public interface IAuthRepository
    {
        Task<Usuario> Auth(AuthRequest request);
    }
}
