import React from "react";
import TeamListPage from "../pages/TeamListPage";
import TeamEditPage from "../pages/TeamEditPage";
import { ACCOUNT_PAGE, TEAM_EDIT_PAGE, TEAM_LIST_PAGE } from "../pages/constants/pageNames";
import AccountPage from "../pages/AccountPage";

function PageSelector(props) {

    // Render
    if (props.page == TEAM_LIST_PAGE) {
        return (
            <TeamListPage 
                setPage={props.setPage}
                teams={props.teams}
                setTeams={props.setTeams}
                setActiveTeamId={props.setActiveTeamId}
                data={props.data}
            />
        );
    }
    else if (props.page == TEAM_EDIT_PAGE) {
        return (
            <TeamEditPage
                setPage={props.setPage}
                team={props.teams.find(x => x.id == props.activeTeamId)}
                setTeams={props.setTeams}
                activeTeamId={props.activeTeamId}
                data={props.data}
            />
        );
    }
    else if (props.page == ACCOUNT_PAGE) {
        return (
            <AccountPage
                setPage={props.setPage}
            />
        )
    }
}

export default PageSelector;