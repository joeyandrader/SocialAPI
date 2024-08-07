using Application.Facade;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController(PostFacade _postFacade) : ControllerBase
    {
        /// <summary>
        /// Create method
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Post createDTO)
        {
            try
            {
                var result = await _postFacade.CreateAsync(createDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _postFacade.GetAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _postFacade.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Post updateDTO)
        {
            try
            {
                var result = await _postFacade.UpdateAsync(updateDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _postFacade.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
