import React, { useState } from "react";
import TeamEditMenu from "../components/TeamEditPage/TeamEditMenu/TeamEditMenu";
import PokemonEditWindow from "../components/TeamEditPage/PokemonEditWindow/PokemonEditWindow";
import OptionsWindow from "../components/TeamEditPage/OptionsWindow/OptionsWindow";
import { POKEMON_FIELD } from "../components/TeamEditPage/PokemonEditWindow/constants/fieldNames";
import createNewPokemonEdit from "../models/pokemonEditFactory";




function TeamEditPage(props) {
    const [activeField, setActiveField] = useState(POKEMON_FIELD);  // matches name attribute of active input element
    const [activeTeamSlot, setActiveTeamSlot] = useState(1); // 1-based indexing currently
    const [teamEdit, setTeamEdit] = useState(teamToTeamEdit(props.team, props.data))

    let activePokemon = teamEdit.pokemon.find(x => x.teamSlot == activeTeamSlot);



    // Render
    return (
        <>
            <TeamEditMenu
                setPage={props.setPage}
                teamEdit={teamEdit}
                setTeamEdit={setTeamEdit}
                activeTeamSlot={activeTeamSlot}
                setActiveTeamSlot={setActiveTeamSlot}
                data={props.data}
            />
            <PokemonEditWindow 
                activePokemon={activePokemon}
                setActiveField={setActiveField}
                teamEdit={teamEdit}
                setTeamEdit={setTeamEdit}
                data={props.data}
            />
            <OptionsWindow
                activePokemon={activePokemon}
                activeField={activeField}
                setTeamEdit={setTeamEdit}
                data={props.data}
            />
        </>
    )
}



function teamToTeamEdit(team, data) {
    return {
        id: team.id,
        teamName: team.teamName,
        pokemon: team.pokemon.map(pokemon => createNewPokemonEdit({
            id: pokemon.id,
            teamSlot: pokemon.teamSlot,
            pokemonName: data.pokemon.find(x => x.id == pokemon.pokemonId)?.identifier || "",
            nickname: pokemon.nickname || "",
            level: pokemon.level,
            gender: data.genders.find(x => x.id == pokemon.genderId)?.identifier || "auto",    // NEED TO MAKE GENDER API ENDPOINT
            shiny: pokemon.shiny,
            teraPkmnTypeId: String(pokemon.teraPkmnTypeId) || "1",
            itemName: data.items.find(x => x.id == pokemon.itemId)?.identifier || "",
            abilityName: data.abilities.find(x => x.id == pokemon.abilityId)?.identifier || "",

            move1Name: data.moves.find(x => x.id == pokemon.move1Id)?.identifier || "",
            move2Name: data.moves.find(x => x.id == pokemon.move2Id)?.identifier || "",
            move3Name: data.moves.find(x => x.id == pokemon.move3Id)?.identifier || "",
            move4Name: data.moves.find(x => x.id == pokemon.move4Id)?.identifier || "",

            natureId: String(pokemon.natureId) || "1",

            hpEV: String(pokemon.hpEV),
            attackEV: String(pokemon.attackEV),
            defenseEV: String(pokemon.defenseEV),
            specialAttackEV: String(pokemon.specialAttackEV),
            specialDefenseEV: String(pokemon.specialDefenseEV),
            speedEV: String(pokemon.speedEV ),

            hpIV: String(pokemon.hpIV),
            attackIV: String(pokemon.attackIV),
            defenseIV: String(pokemon.defenseIV),
            specialAttackIV: String(pokemon.specialAttackIV),
            specialDefenseIV: String(pokemon.specialDefenseIV),
            speedIV: String(pokemon.speedIV)          
        }))
    } 
}


export default TeamEditPage;