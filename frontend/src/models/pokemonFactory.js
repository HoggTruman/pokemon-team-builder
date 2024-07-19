// IS THIS NEEDED??

function createNewPokemon(teamSlot = 1) {
    return (
        {
            id: null,
            teamSlot: teamSlot,
            pokemonId: null,
            nickname: null,
            level: 100,
            genderId: null,
            shiny: false,
            teraPkmnTypeId: null,
            itemId: null,
            abilityId: null,

            move1Id: null,
            move2Id: null,
            move3Id: null,
            move4Id: null,

            natureId: null,
            hpEV: 0,
            attackEV: 0,
            defenseEV: 0,
            specialAttackEV: 0,
            specialDefenseEV: 0,
            speedEV: 0,

            hpIV: 31,
            attackIV: 31,
            defenseIV: 31,
            specialAttackIV: 31,
            specialDefenseIV: 31,
            speedIV: 31
        }
    );
}


export default createNewPokemon;

