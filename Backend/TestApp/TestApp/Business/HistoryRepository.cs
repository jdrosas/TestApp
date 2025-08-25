using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Entitys;
using TestApp.Entitys.Dtos;
using TestApp.Repository.IRepository;

namespace TestApp.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public HistoryRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<HistoryCreateDto> CreateHistoryAsync(HistoryCreateDto newHistoryDto)
        {
            if (await ExistsUrl(newHistoryDto.UrlGif) && await ExistsFactInfo(newHistoryDto.FactInfo))
                throw new Exception($"No se guardan datos duplicados");

            History newEntity = _mapper.Map<History>(newHistoryDto);

            await _db.History.AddAsync(newEntity);

            await SaveAsync();

            return newHistoryDto;
        }

        public async Task<ICollection<HistoryDto>> GetHistoryAsync()
        {
            List<History> entities = await _db.History.OrderBy(h => h.Id).ToListAsync();

            ICollection<HistoryDto> historyDtos = _mapper.Map<ICollection<HistoryDto>>(entities);

            return historyDtos;
        }

        public async Task<bool> ExistsUrl(string? urlGif)
        {
            return await _db.History.AnyAsync(d => d.UrlGif == urlGif);
        }
        public async Task<bool> ExistsFactInfo(string? urlGif)
        {
            return await _db.History.AnyAsync(d => d.FactInfo == urlGif);
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _db.SaveChangesAsync() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al guardar en base de datos", ex);
            }
        }
    }
}
