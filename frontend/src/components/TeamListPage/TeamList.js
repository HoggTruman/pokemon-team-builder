import React from "react";
import TeamInList from "./TeamInList";


function TeamList(props) {


    // Render
    let teamRender = props.teams.map((team, teamIndex) => (
        <TeamInList 
            key={team.id}
            team={team}
            setTeams={props.setTeams}
            setPage={props.setPage}
            setActiveTeamId={props.setActiveTeamId}
            setActivePokemonSlot={props.setActivePokemonSlot}
        />
    ));

    return (
        <div id="teamList">
            {teamRender.length !== 0? teamRender: "You have no teams, create a new one to get started!"}
        </div>
    );
}



export default TeamList;