import React from "react";
import TeamInList from "./TeamInList";


function TeamList(props) {


    const TEAMS = [
        {},
    ];

    let teamRender = TEAMS.map((team, teamIndex) => (
        <TeamInList 
            key={"TEAMID"}
        />
    ));

    return (
        <div id="team-list">
            {teamRender}
        </div>
    );
}



export default TeamList;