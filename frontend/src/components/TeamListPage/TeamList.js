import React from "react";
import TeamInList from "./TeamInList";


function TeamList(props) {


    // Render
    let teamRender = props.teams.map((team, teamIndex) => (
        <TeamInList 
            key={"TEAMID"}
            team={team}
            setPage={props.setPage}
        />
    ));

    return (
        <div id="teamList">
            {teamRender}
        </div>
    );
}



export default TeamList;