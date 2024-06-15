using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

/*
COULD THIS JUST BE INCLUDED IN POKEMON?? NOT SURE IT IS NECESSARY TO HAVE SEPARATELY, ADDS CLUTTER
*/


namespace api.Models 
{
    [Table("BaseStats")]
    public class BaseStats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PokemonId { get; set; }

        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }


        public Pokemon Pokemon { get; set; } = default!;
    }
}