using TestApp.Entitys.Dtos;

namespace TestApp.Services.Interfaces
{
    public interface IFactService
    {
        Task<FactDto?> GetFactAsync();
    }
}
