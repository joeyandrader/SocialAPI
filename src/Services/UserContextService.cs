using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Contracts.Service;

namespace RedeSocialAPI.src.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserContextData GetUserContextData()
        {
            if (_httpContextAccessor.HttpContext.Items.TryGetValue("UserContextData", out var userContextData))
            {
                return userContextData as UserContextData;
            }
            return null;
        }
    }
}
