using Microsoft.AspNetCore.Mvc;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.Middlewares;

namespace RedeSocialAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : BaseController
    {
        private readonly ILikeService _service;
        public LikeController(ILikeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Registra um like
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] Like createDTO)
        {
            try
            {
                return BuildResponse(await _service.Create(createDTO), message: "Like registrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}");
            }
        }

    }
}
