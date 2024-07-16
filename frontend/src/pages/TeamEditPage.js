import React, { useState } from "react";
import TeamEditMenu from "../components/TeamEditPage/TeamEditMenu/TeamEditMenu";
import PokemonEditWindow from "../components/TeamEditPage/PokemonEditWindow/PokemonEditWindow";
import OptionsWindow from "../components/TeamEditPage/OptionsWindow/OptionsWindow";
import { POKEMON_FIELD } from "../components/TeamEditPage/PokemonEditWindow/constants/fieldNames";




function TeamEditPage(props) {
    const [activeField, setActiveField] = useState(POKEMON_FIELD);  // match name attribute of active element

    return (
        <>
            <TeamEditMenu
                setPage={props.setPage}
                team={props.team}
                setTeams={props.setTeams}
                activePokemonSlot={props.activePokemonSlot}
                setActivePokemonSlot={props.setActivePokemonSlot}
            />
            <PokemonEditWindow 
                activePokemon={props.team.pokemon.find(x => x.teamSlot == props.activeTeamSlot)}
                setActiveField={setActiveField}
            />
            <OptionsWindow 
                activeField={activeField} 
            />
        </>
    )
}


export default TeamEditPage;