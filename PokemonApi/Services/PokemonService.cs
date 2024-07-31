using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace PokemonApi.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<string>> GetHiddenAbilities(string pokemonName)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}");
            var json = JsonDocument.Parse(response);

            return json.RootElement.GetProperty("abilities")
                .EnumerateArray()
                .Where(a => a.GetProperty("ability").GetProperty("is_hidden").GetBoolean())
                .Select(a => a.GetProperty("ability").GetProperty("name").GetString());
        }
    }
}