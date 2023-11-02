using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.Models.Request;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.Middlewares;

namespace RedeSocialAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : BaseController
    {
        #region Constructor
        private readonly IPhotoService _service;
        public PhotoController(IPhotoService service)
        {
            _service = service;
        }
        #endregion

        [HttpPost("create/{postId}")]
        [Authorize(Roles = "Comum")]
        public async Task<ActionResult> Create(int postId, List<IFormFile> file)
        {
            try
            {
                return BuildResponse(await _service.Create(file, postId), message: "Upload feito com sucesso!");
            }
            catch (Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", success: false);
            }
        }
    }
}
