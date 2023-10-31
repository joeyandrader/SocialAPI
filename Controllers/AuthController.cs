using Microsoft.AspNetCore.Mvc;
using RedeSocialAPI.Models.Request;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.Middlewares;

namespace RedeSocialAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        /// <summary>
        /// Metodo de login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("auth")]
        public async Task<ActionResult> Auth(AuthRequest request)
        {
            try
            {
                return BuildResponse(await _service.Auth(request), message: "Logado com sucesso!");
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", success: false);
            }
        }
    }
}
