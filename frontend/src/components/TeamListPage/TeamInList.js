import React from "react";

import "./TeamInList.css";


function TeamInList(props) {
    function handleClickTeamButton() {
        props.setPage("team_edit");
        props.setActiveTeamId(props.team.id);
        props.setActivePokemonSlot(1);
    }




    // Render
    let icons = props.team.pokemon.map((pokemon, pokemonIndex) => (
        <img src="" alt={pokemon.pokemonId + " "} />
    ));

    return (
        <div 
            className="teamInList"
            key={props.id}
        >
            <button className="teamButton" onClick={handleClickTeamButton}>
                <p>{props.team.teamName}</p>
                <div id="teamInListIcons">
                    {icons}
                </div>
            </button>
            <button
                onClick={() => "edit name window"}
            >
                edit name
            </button>
            <button
                onClick={() => "confirm delete team"}
            >
                delete
            </button>
        </div>
    )
}


export default TeamInList;