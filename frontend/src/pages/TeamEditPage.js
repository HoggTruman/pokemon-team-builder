import React, { useState } from "react";
import TeamEditMenu from "../components/TeamEditPage/TeamEditMenu/TeamEditMenu";
import PokemonEditWindow from "../components/TeamEditPage/PokemonEditWindow/PokemonEditWindow";
import OptionsWindow from "../components/TeamEditPage/OptionsWindow/OptionsWindow";
import { POKEMON_FIELD } from "../components/TeamEditPage/PokemonEditWindow/constants/fieldNames";




function TeamEditPage(props) {
    const newTeamEdit = {
        teamName: props.team.teamName,
        pokemon: props.team.pokemon.map(pokemon => ({
            id: pokemon.id,
            teamSlot: pokemon.teamSlot,
            pokemonName: props.data.pokemon.find(x => x.id == pokemon.pokemonId)?.identifier || "",
            nickname: pokemon.nickname,
            level: pokemon.level,
            genderId: pokemon.genderId,
            shiny: pokemon.shiny,
            teraPkmnTypeId: pokemon.teraPkmnTypeId,
            itemName: props.data.item.find(x => x.id == pokemon.itemId)?.identifier || "",
            abilityName: props.data.ability.find(x => x.id == pokemon.abilityId)?.identifier || "",

            move1Name: props.data.move.find(x => x.id == pokemon.move1Id)?.identifier || "",
            move2Name: props.data.move.find(x => x.id == pokemon.move2Id)?.identifier || "",
            move3Name: props.data.move.find(x => x.id == pokemon.move3Id)?.identifier || "",
            move4Name: props.data.move.find(x => x.id == pokemon.move4Id)?.identifier || "",

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


    const [activeField, setActiveField] = useState(POKEMON_FIELD);  // match name attribute of active element
    const [activePokemonSlot, setActivePokemonSlot] = useState(1); // 1-based indexing currently
    const [teamEdit, setTeamEdit] = useState(newTeamEdit)

    return (
        <>
            <TeamEditMenu
                setPage={props.setPage}
                teamEdit={teamEdit}
                setTeamEdit={setTeamEdit}
                activePokemonSlot={activePokemonSlot}
                setActivePokemonSlot={setActivePokemonSlot}
            />
            <PokemonEditWindow 
                activePokemon={props.team.pokemon.find(x => x.teamSlot == props.activeTeamSlot)}
                setActiveField={setActiveField}
            />
            <OptionsWindow 
                activeField={activeField}
                data={props.data}
            />
            <h1>{activePokemonSlot}</h1>
        </>
    )
}


export default TeamEditPage;