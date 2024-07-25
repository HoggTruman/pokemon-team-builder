import React from "react";
import TeamList from "../components/TeamListPage/TeamList";
import createNewTeam from "../models/teamFactory";
import { TEAM_EDIT_PAGE } from "./constants/pageNames";


function TeamListPage(props) {
    function handleClickNewTeamButton() {
        const newTeam = createNewTeam({id: -Date.now()});  // Use negative id for new teams/pokemon

        props.setTeams(teams => {
            teams.push(newTeam);
            return [...teams];
        })
        
        props.setActiveTeamId(newTeam.id);
        props.setPage(TEAM_EDIT_PAGE);
    }


    return (
        <>
            <h1>Teams</h1>
            <h2>Select a team or create a new one</h2>

            <button
                id="newTeamButton"
                onClick={handleClickNewTeamButton}
            >
                New Team
            </button>

            <button>Get teams from server/ save teams to server</button>

            <TeamList
                setPage={props.setPage}
                teams={props.teams}
                setTeams={props.setTeams}
                setActiveTeamId={props.setActiveTeamId}
                data={props.data}
            />
        </>
    )
}



export default TeamListPage;