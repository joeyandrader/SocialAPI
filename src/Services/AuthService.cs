using RedeSocialAPI.Models.Data;
using RedeSocialAPI.Models.Request;
using RedeSocialAPI.Models.Response;
using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.Middlewares;

namespace RedeSocialAPI.src.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Cria token  ao logar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthResponse> Auth(AuthRequest request)
        {
            Usuario user = await _repository.Auth(request);
            if (user == null)
                throw new Exception("Dados Invalido!");
            var verifyPassword = user.ValidaSenha(request.Password);
            if (!verifyPassword)
                throw new Exception("Dados Invalido");
            return TokenService.GenerateToken(user);
        }
    }
}
