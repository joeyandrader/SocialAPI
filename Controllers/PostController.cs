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
        /// Update By Id postagem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        [HttpPatch("updatePatch/{id}")]
        public async Task<ActionResult> UpdateById(int id, [FromBody] Post updateDTO)
        {
            try
            {
                return BuildResponse(await _service.UpdateById(id, updateDTO), message: "Postagem atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", success: false);
            }
        }

        /// <summary>
        /// Update postagem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] Post updateDTO)
        {
            try
            {
                return BuildResponse(await _service.Update(updateDTO), message: "Postagem atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", success: false);
            }
        }

        /// <summary>
        /// Get Postagem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return BuildResponse(await _service.Get(id));
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
