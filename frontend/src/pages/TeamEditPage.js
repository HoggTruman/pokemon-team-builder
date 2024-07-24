import React, { useState } from "react";
import TeamEditMenu from "../components/TeamEditPage/TeamEditMenu/TeamEditMenu";
import PokemonEditWindow from "../components/TeamEditPage/PokemonEditWindow/PokemonEditWindow";
import OptionsWindow from "../components/TeamEditPage/OptionsWindow/OptionsWindow";
import { POKEMON_FIELD } from "../components/TeamEditPage/PokemonEditWindow/constants/fieldNames";
import { teamToTeamEdit } from "../mappers/teamToTeamEdit";




function TeamEditPage(props) {
    const [activeField, setActiveField] = useState(POKEMON_FIELD);  // matches name attribute of active input element
    const [activeTeamSlot, setActiveTeamSlot] = useState(1); // 1-based indexing currently
    const [teamEdit, setTeamEdit] = useState(teamToTeamEdit(props.team, props.data))

    let activePokemon = teamEdit.pokemon.find(x => x.teamSlot == activeTeamSlot);


    console.log(teamEdit)



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



export default TeamEditPage;