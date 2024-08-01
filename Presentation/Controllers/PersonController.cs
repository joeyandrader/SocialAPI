using Application.Facade;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController(PersonFacade _personFacade) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Person createDTO)
        {
            try
            {
                var result = await _personFacade.CreateAsync(createDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
