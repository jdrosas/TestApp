using Microsoft.AspNetCore.Mvc;
using TestApp.Entitys.Dtos;
using TestApp.Services.Interfaces;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GifController : ResponseController
    {
        private readonly IGifService _gifService;

        public GifController(IGifService gifService)
        {
            _gifService = gifService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGifAsync(string query)
        {
            try
            {
                List<GifDto> gif = await _gifService.GetGifAsync(query);
                SetDataResponse(gif);
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
