using TestApp.Entitys.Dtos;

namespace TestApp.Repository.IRepository
{
    public interface IHistoryRepository
    {
        Task<ICollection<HistoryDto>> GetHistoryAsync();
        Task<HistoryCreateDto> CreateHistoryAsync(HistoryCreateDto historyCreateDto);
        Task<bool> SaveAsync();
    }
}
