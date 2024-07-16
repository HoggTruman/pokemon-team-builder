import React from "react";
import TeamList from "../components/TeamListPage/TeamList";
import createNewTeam from "../models/teamFactory";


function TeamListPage(props) {
    function handleClickNewTeamButton() {
        const newTeam = createNewTeam(Date.now());  // MAYBE NEED AN UPDATE TEAMS ENDPOINT THAT CHECKS IF EACH ID IS ALREADY IN THE DB AND CREATES/UPDATES ACCORDINGLY

        props.setTeams(teams => {
            teams.push(newTeam);
            return [...teams];
        })
        
        props.setActiveTeamId(newTeam.id);
        props.setActivePokemonSlot(1);
        props.setPage("team_edit");
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
                setActiveTeamId={props.setActiveTeamId}
                setActivePokemonSlot={props.setActivePokemonSlot}
            />
        </>
    )
}



export default TeamListPage;