using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.Models.ViewObjects;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.Middlewares;

namespace RedeSocialAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        #region Constructor
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }
        #endregion

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] Usuario createDTO)
        {
            var createUser = await _service.Create(createDTO);
            try
            {
                return BuildResponse(createUser, message: "Usuario Criado com sucesso");
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"Erro ao cadastrar usuario", success: false);
            }
        }

        /// <summary>
        /// Get an user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        [Authorize(Roles = "Comum")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return BuildResponse(await _service.Get(id), message: "Usuario encontrado!");
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", success: false);
            }
        }

        [HttpGet("usrInfo")]
        public async Task<ActionResult> GetUserInfo()
        {
            try
            {
                return BuildResponse(await _service.GetUserInfo());
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", success: false);
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns> <summary>
        [HttpPut("Update")]
        [Authorize(Roles = "Comum")]
        public async Task<ActionResult> Update([FromBody] Usuario updateDTO)
        {
            try
            {
                var user = await _service.Update(updateDTO);
                return BuildResponse(user, message: "Usuario atualizado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return BuildResponse(message: $"Error: {ex.Message}", success: false);
            }
        }


        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Comum")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _service.Delete(id);
            try
            {
                return BuildResponse(message: "Deletado com sucesso");
            }
            catch (System.Exception ex)
            {
                return BuildResponse(message: $"Error: {ex.Message}", success: user);
            }
        }

        [HttpPatch("updatePatch/{id}")]
        [Authorize(Roles = "Comum")]
        public async Task<ActionResult> UpdateById(int id, [FromBody] UsuarioVO updateDTO)
        {
            try
            {
                return BuildResponse(await _service.UpdateById(id, updateDTO));
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"Error: {ex.Message}", success: false);
            }
        }

    }
}