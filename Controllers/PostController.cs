using Microsoft.AspNetCore.Mvc;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.Middlewares;

namespace RedeSocialAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : BaseController
    {
        #region Constructor
        private readonly IPostService _service;
        public PostController(IPostService service)
        {
            _service = service;
        }
        #endregion

        /// <summary>
        /// Cria postagem
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] Post createDTO)
        {
            try
            {
                return BuildResponse(await _service.Create(createDTO), message: "Postagem criada com sucesso!");
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", success: false);
            }
        }

        /// <summary>
        /// Lista postagem
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ActionResult> List()
        {
            try
            {
                return BuildResponse(await _service.List());
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", success: false);
            }
        }
    }
}
