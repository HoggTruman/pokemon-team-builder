import React from "react";
import TeamList from "../components/TeamListPage/TeamList";
import createNewTeam from "../models/teamFactory";
import { TEAM_EDIT_PAGE } from "./constants/pageNames";


function TeamListPage(props) {
    function handleClickNewTeamButton() {
        // NEED A BETTER WAY TO MAKE GUIDS FOR TEAMS NOT OBTAINED FROM THE DB!!!!!!!!!!!!!!! NEEDS TO ENSURE IT WONT MATCH A TEAM ALREADY IN DB (NEEDS DIFFERENT FORMAT)
        const newTeam = createNewTeam(Date.now());  // MAYBE NEED AN UPDATE TEAMS ENDPOINT THAT CHECKS IF EACH ID IS ALREADY IN THE DB AND CREATES/UPDATES ACCORDINGLY

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
            />
        </>
    )
}



export default TeamListPage;