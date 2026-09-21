using System.Text.Json;
using System.Net.Http;

namespace PROJECTNAME.Services
{
    public class JsonContentService : IJsonContentService
    {
        private readonly HttpClient _http;

        public JsonContentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<T?> LoadAsync<T>(string path)
        {
            var response = await _http.GetAsync(path);
            if (!response.IsSuccessStatusCode)
                return default;

            var text = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(text))
                return default;

            if (!text.TrimStart().StartsWith("{"))
                return default;

            return JsonSerializer.Deserialize<T>(
                text,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}