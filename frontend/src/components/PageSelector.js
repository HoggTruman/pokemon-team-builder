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
            />
        );
    }
    else if (props.page == "team_edit") {
        return (
            <TeamEditPage
                setPage={props.setPage}
                teams={props.teams}
            />
        );
    }    
}

export default PageSelector;