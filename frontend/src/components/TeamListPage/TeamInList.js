import React from "react";

import { TEAM_EDIT_PAGE } from "../../pages/constants/pageNames";

import "./TeamInList.css";
import { pokemonIcons } from "../../assets/assets";



function TeamInList(props) {
    function handleClickTeamButton() {
        props.setPage(TEAM_EDIT_PAGE);
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


    function getIcon(pokemonId) {
        const pokemon = props.data.pokemon.find(x => x.id == pokemonId);
        const identifier = pokemon?.identifier || "_unknown";
        return pokemonIcons[identifier]
    }



    // Render
    let icons = props.team.pokemon.map(pokemon => (
        <div
            key={pokemon.id} 
            className="iconFrame"
        >
            <img 
                src={getIcon(pokemon.pokemonId)}
                className="icon"
            />
        </div>
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
                <div className="teamIcons">
                    <span className="iconHelper"></span>
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