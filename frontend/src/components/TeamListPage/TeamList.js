import React from "react";
import TeamInList from "./TeamInList";


function TeamList(props) {


    // Render
    let teamRender = props.teams.map((team, teamIndex) => (
        <TeamInList 
            key={team.id}
            team={team}
            setPage={props.setPage}
            setActiveTeamId={props.setActiveTeamId}
            setActivePokemonSlot={props.setActivePokemonSlot}
        />
    ));

    return (
        <div id="teamList">
            {teamRender}
        </div>
    );
}



export default TeamList;