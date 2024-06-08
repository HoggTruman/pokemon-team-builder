namespace api.DTOs.PokemonAbility
{
    public class PokemonAbilityDTO
    {
        public int Id { get; set; }
        public string? Identifier { get; set; }
        public string? FlavorText { get; set; }
        public int Slot { get; set; }
    }
}