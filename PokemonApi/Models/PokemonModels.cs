using System.Collections.Generic;

namespace PokemonApi.Models
{
    public class Ability
    {
        public string name { get; set; } = string.Empty;
        public bool is_hidden { get; set; }
    }

    public class PokemonAbility
    {
        public Ability ability { get; set; } = new Ability();
    }

    public class Pokemon
    {
        public string name { get; set; } = string.Empty;
        public List<PokemonAbility> abilities { get; set; } = new List<PokemonAbility>();
    }
}
