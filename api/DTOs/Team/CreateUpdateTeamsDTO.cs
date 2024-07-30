using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using api.DTOs.UserPokemon;

namespace api.DTOs.Team;

public class CreateUpdateTeamsDTO : IValidatableObject
{
    public int Id { get; set; }
    public string TeamName { get; set; } = "";

    [MaxLength(6, ErrorMessage = "A team can not have more than 6 pokemon")]
    [JsonPropertyName("pokemon")]
    public List<CreateUserPokemonDTO> UserPokemon { get; set; } = [];




    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var teamSlotSet = new HashSet<int>(UserPokemon.Select(x => x.TeamSlot));

        if (teamSlotSet.Count != UserPokemon.Count)
        {
            yield return new ValidationResult(
                "Each pokemon must have a unique team slot"
            );
        }
    }
}