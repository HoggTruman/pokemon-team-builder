import React from "react";
import TeamList from "../components/TeamListPage/TeamList";
import createNewTeam from "../models/teamFactory";
import { ACCOUNT_PAGE, TEAM_EDIT_PAGE } from "./constants/pageNames";
import { userContext } from "../context/userContext";
import { getAllTeamsAPI } from "../services/api/teamAPI";


function TeamListPage(props) {
    const { token, isLoggedIn } = userContext();

    async function handleClickGetTeamsButton() {
        // This button is needed so that changes arent overwritten on refresh? (if you loaded teams with page load)
        if (isLoggedIn() === false) {
            props.setPage(ACCOUNT_PAGE);
        }

        const serverTeams = await getAllTeamsAPI(token);

        if (serverTeams === undefined || confirm("Warning: Changes not saved to teams on server will be lost. Continue?") === false) {
            return;
        }

        props.setTeams(teams => {
            // replace only the server teams, not local teams
            const localTeams = teams.filter(team => team.id < 0);

            return localTeams.concat(serverTeams);
        })
    }


    async function handleClickSaveTeamsButton() {
        for(const team of props.teams) {
            if (team.id > 0) {
                // const result = await updateTeamByIdAPI(team.id, team, token);
            }
            else if (team.id < 0) {
                // const result = await createTeamAPI(team, token);
            }
        }
    }




    function handleClickNewTeamButton() {
        const newTeam = createNewTeam({id: -Date.now()});  // Use negative id for new teams/pokemon

        props.setTeams(teams => {
            teams.push(newTeam);
            return [...teams];
        })
        
        props.setActiveTeamId(newTeam.id);
        props.setPage(TEAM_EDIT_PAGE);
    }

    // Render 
    const serverTeams = props.teams.filter(team => team.id > 0);
    const localTeams = props.teams.filter(team => team.id < 0);


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

            <button
                id="getTeamsButton"
                onClick={handleClickGetTeamsButton}
            >
                Get teams from server
            </button>

            <button
                id="saveTeamsButton"
                onClick={handleClickSaveTeamsButton}
            >
                Save teams to server
            </button>

            <h2>
                {`Teams On Server (${serverTeams.length})`}
            </h2>
            <TeamList
                setPage={props.setPage}
                teams={serverTeams}
                setTeams={props.setTeams}
                setActiveTeamId={props.setActiveTeamId}
                data={props.data}
            />

            <h2>
                {`Local Teams (${localTeams.length})`}
            </h2>
            <TeamList
                setPage={props.setPage}
                teams={localTeams}
                setTeams={props.setTeams}
                setActiveTeamId={props.setActiveTeamId}
                data={props.data}
            />
        </>
    )
}



export default TeamListPage;