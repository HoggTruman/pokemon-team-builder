function createNewPokemonEdit({
    id = null,
    teamSlot = 1,
    pokemonName = "",
    nickname = "",
    level = 100,
    genderId = null,
    shiny = false,
    teraPkmnTypeId = null,
    itemName = "",
    abilityName = "",

    move1Name = "",
    move2Name = "",
    move3Name = "",
    move4Name = "",

    natureId = null,
    hpEV = 0,
    attackEV = 0,
    defenseEV = 0,
    specialAttackEV = 0,
    specialDefenseEV = 0,
    speedEV = 0,

    hpIV = 31,
    attackIV = 31,
    defenseIV = 31,
    specialAttackIV = 31,
    specialDefenseIV = 31,
    speedIV = 31
}={}) {
    return (
        {
            id: id || `${teamSlot}${Date.now()}` ,
            teamSlot: teamSlot,
            pokemonName: pokemonName,
            nickname: nickname,
            level: level,
            genderId: genderId,
            shiny: shiny,
            teraPkmnTypeId: teraPkmnTypeId,
            itemName: itemName,
            abilityName: abilityName,

            move1Name: move1Name,
            move2Name: move2Name,
            move3Name: move3Name,
            move4Name: move4Name,

            natureId: natureId,
            hpEV: hpEV,
            attackEV: attackEV,
            defenseEV: defenseEV,
            specialAttackEV: specialAttackEV,
            specialDefenseEV: specialDefenseEV,
            speedEV: speedEV,

            hpIV: hpIV,
            attackIV: attackIV,
            defenseIV: defenseIV,
            specialAttackIV: specialAttackIV,
            specialDefenseIV: specialDefenseIV,
            speedIV: speedIV      
        }
    );
}


export default createNewPokemonEdit;
