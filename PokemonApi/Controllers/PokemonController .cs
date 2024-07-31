using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using PokemonApi.Services;

namespace PokemonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("habilidadesOcultas/{pokemon}")]
        [Authorize]
        public async Task<IActionResult> GetHiddenAbilities(string pokemon)
        {
            var abilities = await _pokemonService.GetHiddenAbilities(pokemon);
            return Ok(new { habilidades = new { ocultas = abilities } });
        }
    }
}