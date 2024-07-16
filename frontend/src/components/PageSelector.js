import React from "react";
import TeamListPage from "../pages/TeamListPage";
import TeamEditPage from "../pages/TeamEditPage";

function PageSelector(props) {

    // Render
    if (props.page == "team_list") {
        return (
            <TeamListPage 
                setPage={props.setPage}
                teams={props.teams}
                setTeams={props.setTeams}
                setActiveTeamId={props.setActiveTeamId}
            />
        );
    }
    else if (props.page == "team_edit") {
        return (
            <TeamEditPage
                setPage={props.setPage}
                team={props.teams.find(x => x.id == props.activeTeamId)}
                setTeams={props.setTeams}
                activeTeamId={props.activeTeamId}
            />
        );
    }    
}

export default PageSelector;