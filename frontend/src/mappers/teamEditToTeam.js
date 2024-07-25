import createNewPokemon from "../models/pokemonFactory";
import createNewTeam from "../models/teamFactory";


export function teamEditToTeam(teamEdit, data) {
    function convertLevel(level) {
        const numLevel = Number(level);

        if (
            Number.isNaN(numLevel) === false &&
            Number.isInteger(numLevel) &&
            numLevel <= 100 &&
            numLevel >= 1
        ) {
            return numLevel;
        }

        return 100;
    }

    function getGenderId(gender, pokemonData) {
        let genderId;

        if (gender == "auto") {
            genderId = pokemonData?.genders[0].id;
        }
        else {
            genderId = data.genders.find(x => x.identifier == gender)?.id;
        }
        
        return genderId;
    }

    function getItemId(itemName) {
        return data.items.find(x => x.identifier == itemName.toLowerCase().trim())?.id;
    }

    function getAbilityId(abilityName, pokemonData) {
        const abilityId = data.items.find(x => x.identifier == abilityName.toLowerCase().trim())?.id;
        if (pokemonData?.abilities.includes(abilityId)) {
            return abilityId;
        }

        return null;
    }

    function getMoveId(moveName, pokemonData) {
        const moveId = data.items.find(x => x.identifier == moveName.toLowerCase().trim())?.id;
        if (pokemonData?.moves.includes(moveId)) {
            return moveId;
        }

        return null;
    }

    function convertIV(iv) {
        const numIV = Number(iv);

        if (
            Number.isNaN(numIV) === false &&
            Number.isInteger(numIV) &&
            numIV <= 31 &&
            numIV >= 0
        ) {
            return numIV;
        }

        return 31;
    }


    const pokemonList = teamEdit.pokemon.map(pokemonEdit => {
        const pokemonData = data.pokemon.find(x => x.identifier == pokemonEdit.pokemonName.toLowerCase().trim());
        
        return createNewPokemon({
            id: pokemonEdit.id,
            teamSlot: pokemonEdit.teamSlot,
            pokemonId: pokemonData?.id,
            nickname: pokemonEdit.nickname === ""? null: pokemonEdit.nickname,
            level: convertLevel(pokemonEdit.level),
            genderId: getGenderId(pokemonEdit.gender, pokemonData),

            shiny: pokemonEdit.shiny,
            teraPkmnTypeId: Number(pokemonEdit.teraPkmnTypeId),
            itemId: getItemId(pokemonEdit.itemName),
            abilityId: getAbilityId(pokemonEdit.abilityName, pokemonData),

            move1Id: getMoveId(pokemonEdit.move1Name, pokemonData),  // need other checking for duplicate moves?? maybe handle validation elsewhere
            move2Id: getMoveId(pokemonEdit.move2Name, pokemonData),
            move3Id: getMoveId(pokemonEdit.move3Name, pokemonData),
            move4Id: getMoveId(pokemonEdit.move4Name, pokemonData),

            natureId: Number(pokemonEdit.natureId),

            hpEV: Number(pokemonEdit.hpEV),
            attackEV: Number(pokemonEdit.attackEV),
            defenseEV: Number(pokemonEdit.defenseEV),
            specialAttackEV: Number(pokemonEdit.specialAttackEV),
            specialDefenseEV: Number(pokemonEdit.specialDefenseEV),
            speedEV: Number(pokemonEdit.speedEV),

            hpIV: convertIV(pokemonEdit.hpIV),
            attackIV: convertIV(pokemonEdit.attackIV),
            defenseIV: convertIV(pokemonEdit.defenseIV),
            specialAttackIV: convertIV(pokemonEdit.specialAttackIV),
            specialDefenseIV: convertIV(pokemonEdit.specialDefenseIV),
            speedIV: convertIV(pokemonEdit.speedIV)    
        });
    })

    return createNewTeam({
        id: teamEdit.id,
        teamName: teamEdit.teamName,
        pokemon: pokemonList
    })
}