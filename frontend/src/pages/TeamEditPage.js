import React, { useState } from "react";
import TeamEditMenu from "../components/TeamEditPage/TeamEditMenu/TeamEditMenu";
import PokemonEditWindow from "../components/TeamEditPage/PokemonEditWindow/PokemonEditWindow";
import OptionsWindow from "../components/TeamEditPage/OptionsWindow/OptionsWindow";
import { POKEMON_FIELD } from "../components/TeamEditPage/PokemonEditWindow/constants/fieldNames";
import createNewPokemonEdit from "../models/pokemonEditFactory";




function TeamEditPage(props) {
    // NEED TO HANDLE PROPER TYPE CONVERSIONS??? VALUE ATTRIBUTES USE STRINGS SO MAY GET WEIRDNESS
    const newTeamEdit = {
        id: props.team.id,
        teamName: props.team.teamName,
        pokemon: props.team.pokemon.map(pokemon => createNewPokemonEdit({
            id: pokemon.id,
            teamSlot: pokemon.teamSlot,
            pokemonName: props.data.pokemon.find(x => x.id == pokemon.pokemonId)?.identifier || "",
            nickname: pokemon.nickname,
            level: pokemon.level,
            genderId: pokemon.genderId || "auto",                                                  // PAGE CURRENTLY USES IDENTIFIER INSTEAD OF ID
            shiny: pokemon.shiny,
            teraPkmnTypeId: pokemon.teraPkmnTypeId || 1,
            itemName: props.data.items.find(x => x.id == pokemon.itemId)?.identifier || "",
            abilityName: props.data.abilities.find(x => x.id == pokemon.abilityId)?.identifier || "",

            move1Name: props.data.moves.find(x => x.id == pokemon.move1Id)?.identifier || "",
            move2Name: props.data.moves.find(x => x.id == pokemon.move2Id)?.identifier || "",
            move3Name: props.data.moves.find(x => x.id == pokemon.move3Id)?.identifier || "",
            move4Name: props.data.moves.find(x => x.id == pokemon.move4Id)?.identifier || "",

            natureId: pokemon.natureId,

            hpEV: pokemon.hpEV,
            attackEV: pokemon.attackEV,
            defenseEV: pokemon.defenseEV,
            specialAttackEV: pokemon.specialAttackEV,
            specialDefenseEV: pokemon.specialDefenseEV,
            speedEV: pokemon.speedEV,

            hpIV: pokemon.hpIV,
            attackIV: pokemon.attackIV,
            defenseIV: pokemon.defenseIV,
            specialAttackIV: pokemon.specialAttackIV,
            specialDefenseIV: pokemon.specialDefenseIV,
            speedIV: pokemon.speedIV            
        }))
    } 


    const [activeField, setActiveField] = useState(POKEMON_FIELD);  // matches name attribute of active input element
    const [activeTeamSlot, setActiveTeamSlot] = useState(1); // 1-based indexing currently
    const [teamEdit, setTeamEdit] = useState(newTeamEdit)

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
            <h1>{activeTeamSlot}</h1>
        </>
    )
}


export default TeamEditPage;