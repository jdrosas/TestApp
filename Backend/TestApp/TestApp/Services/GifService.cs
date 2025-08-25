using Microsoft.Extensions.Options;
using System.Net;
using TestApp.Entitys.Dtos;
using TestApp.Security.Resources;
using TestApp.Services.Interfaces;

namespace TestApp.Services
{
    public class GifService : IGifService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public GifService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
        }

        public async Task<List<GifDto>> GetGifAsync(string query)
        {
            string url = $"search?api_key={_apiSettings.ApiKey}&q={query}";

            using HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("401 - No autorizado. Verifica la API Key.");
            }

            response.EnsureSuccessStatusCode(); // lanza excepción para cualquier otro status no exitoso

            GiphyDataWrapper? giphyDataWrapper =
                await response.Content.ReadFromJsonAsync<GiphyDataWrapper>();

            return giphyDataWrapper?.Data ?? new List<GifDto>();
        }
    }
}
