using Microsoft.AspNetCore.Mvc;
using TestApp.Entitys.Dtos;
using TestApp.Services.Interfaces;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactController : ResponseController
    {
        private readonly IFactService _factService;

        public FactController(IFactService factService)
        {
            _factService = factService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFactAsync()
        {
            try
            {
                FactDto? fact = await _factService.GetFactAsync();
                SetDataResponse(fact);
                return Ok(response); 
            }
            catch (Exception ex)
            {
                SetMsgErrorResponse(ex);
                return BadRequest(response);
            }
        }
    }
}
