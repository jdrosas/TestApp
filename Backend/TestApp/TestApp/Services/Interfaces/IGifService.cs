using TestApp.Entitys.Dtos;

namespace TestApp.Services.Interfaces
{
    public interface IGifService
    {
        Task<List<GifDto>> GetGifAsync(string query);
    }
}
