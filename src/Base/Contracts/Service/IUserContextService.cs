using RedeSocialAPI.Models.Data;

namespace RedeSocialAPI.src.Base.Contracts.Service
{
    public interface IUserContextService
    {
        UserContextData GetUserContextData();
    }
}
