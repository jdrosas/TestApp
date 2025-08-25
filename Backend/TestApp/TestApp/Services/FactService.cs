using Microsoft.AspNetCore.Mvc;
using TestApp.Entitys.Dtos;
using TestApp.Services.Interfaces;

namespace TestApp.Services
{
    public class FactService : IFactService
    {
        private readonly HttpClient _httpClient;

        public FactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<FactDto?> GetFactAsync()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync("fact");

            response.EnsureSuccessStatusCode();

            FactDto? fact = await response.Content.ReadFromJsonAsync<FactDto>();
            return fact;
        }
    }
}
