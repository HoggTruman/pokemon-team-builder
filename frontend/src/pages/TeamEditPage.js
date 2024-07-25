import React, { useState } from "react";
import TeamEditMenu from "../components/TeamEditPage/TeamEditMenu/TeamEditMenu";
import PokemonEditWindow from "../components/TeamEditPage/PokemonEditWindow/PokemonEditWindow";
import OptionsWindow from "../components/TeamEditPage/OptionsWindow/OptionsWindow";
import { POKEMON_FIELD } from "../components/TeamEditPage/PokemonEditWindow/constants/fieldNames";
import { teamToTeamEdit } from "../mappers/teamToTeamEdit";
import { teamEditToTeam } from "../mappers/teamEditToTeam";
var deepEqual = require('deep-equal')




function TeamEditPage(props) {
    const [activeField, setActiveField] = useState(POKEMON_FIELD);  // matches name attribute of active input element
    const [activeTeamSlot, setActiveTeamSlot] = useState(1); // 1-based indexing
    const [teamEdit, setTeamEdit] = useState(teamToTeamEdit(props.team, props.data)) // A model used for more convenient editing the team on the page

    let activePokemon = teamEdit.pokemon.find(x => x.teamSlot == activeTeamSlot);


    function saveChanges() {
        const modifiedTeam = teamEditToTeam(teamEdit, props.data);
        // ANY FURTHER CHECKING FOR DUPLICATE MOVES, INVALID DATA ETC...

        props.setTeams(teams => {
            teams = teams.map(team => team.id === modifiedTeam.id? modifiedTeam: team);

            return [...teams];
        })
    }


    function teamHasUnsavedChanges() {
        const modifiedTeam = teamEditToTeam(teamEdit, props.data);
        return deepEqual(modifiedTeam, props.team, {strict: true}) === false;
    }


    

    // Render
    return (
        <>
            <TeamEditMenu
                setPage={props.setPage}
                teamEdit={teamEdit}
                setTeamEdit={setTeamEdit}
                activeTeamSlot={activeTeamSlot}
                setActiveTeamSlot={setActiveTeamSlot}
                saveChanges={saveChanges}
                teamHasUnsavedChanges={teamHasUnsavedChanges}
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