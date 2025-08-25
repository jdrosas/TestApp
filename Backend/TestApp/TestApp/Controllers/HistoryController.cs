using Microsoft.AspNetCore.Mvc;
using TestApp.Entitys.Dtos;
using TestApp.Entitys.Responses;
using TestApp.Repository.IRepository;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ResponseController
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryController(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistoryAsync()
        {
            try
            {
                HistoryDto[] history = (await _historyRepository.GetHistoryAsync()).ToArray();
                SetDataResponse(history);
                return Ok(response);
            }
            catch (Exception ex)
            {
                SetMsgErrorResponse(ex);
                return BadRequest(response);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<DefaultResponse>> CreateHistoryAsync(HistoryCreateDto historyCreateDto)
        {
            try
            {
                HistoryCreateDto? createdHistory = await _historyRepository.CreateHistoryAsync(historyCreateDto);
                SetDataResponse(createdHistory);
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
