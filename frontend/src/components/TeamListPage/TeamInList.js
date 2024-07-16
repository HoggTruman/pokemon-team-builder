import React from "react";

import "./TeamInList.css";


function TeamInList(props) {
    function handleClickTeamButton() {
        props.setPage("team_edit");
        props.setActiveTeamId(props.team.id);
    }


    function handleClickDeleteTeamButton() {
        if (!confirm(`Are you sure you want to delete "${props.team.teamName}"`)) {
            return;
        }

        props.setTeams(teams => {
            return teams.filter(team => team.id != props.team.id);
        });
    }


    function handleClickRenameTeamButton() {
        let newTeamName = prompt("New Team Name:", props.team.teamName);  // MAKE A CUSTOM PROMPT COMPONENT SINCE THIS WILL BE USEFUL FOR NEW TEAM AS WELL

        if (newTeamName != null && newTeamName != "") {
            props.setTeams(teams => {
                props.team.teamName = newTeamName;
                return [...teams];
            })
        }
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
            <button 
                className="teamButton" 
                onClick={handleClickTeamButton}
            >
                <p>{props.team.teamName}</p>
                <div id="teamInListIcons">
                    {icons}
                </div>
            </button>

            <button
                className="renameTeamButton"
                onClick={handleClickRenameTeamButton}
            >
                rename
            </button>

            <button
                className="deleteTeamButton"
                onClick={handleClickDeleteTeamButton}
            >
                delete
            </button>
        </div>
    )
}


export default TeamInList;