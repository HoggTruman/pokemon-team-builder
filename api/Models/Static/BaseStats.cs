using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
COULD THIS JUST BE INCLUDED IN POKEMON?? NOT SURE IT IS NECESSARY TO HAVE SEPARATELY, ADDS CLUTTER
*/


namespace api.Models.Static;

[Table("BaseStats")]
public class BaseStats
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = default!;

    public int HP { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int SpecialAttack { get; set; }
    public int SpecialDefense { get; set; }
    public int Speed { get; set; }
    
}
