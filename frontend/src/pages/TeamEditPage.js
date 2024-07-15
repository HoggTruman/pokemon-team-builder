import React from "react";
import TeamEditMenu from "../components/TeamEditPage/TeamEditMenu/TeamEditMenu";
import PokemonEditWindow from "../components/TeamEditPage/PokemonEditWindow/PokemonEditWindow";
import OptionsWindow from "../components/TeamEditPage/OptionsWindow/OptionsWindow";




function TeamEditPage(props) {


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
            />
            <OptionsWindow activeField={"pokemon"} />
        </>
    )
}


export default TeamEditPage;