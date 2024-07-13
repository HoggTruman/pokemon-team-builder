import React from "react";
import TeamListPage from "../pages/TeamListPage";
import TeamEditPage from "../pages/TeamEditPage";

function PageSelector(props) {

    // Render
    if (props.page == "team_list") {
        return (
            <TeamListPage 
                setPage={props.setPage}
            />
        );
    }
    else if (props.page == "team_edit") {
        return (
            <TeamEditPage
                setPage={props.setPage}
            />
        );
    }    
}

export default PageSelector;