import React from "react";
import TeamList from "../components/TeamListPage/TeamList";
import createNewTeam from "../models/teamFactory";
import { ACCOUNT_PAGE, TEAM_EDIT_PAGE } from "./constants/pageNames";
import { userContext } from "../context/userContext";
import { createUpdateTeamsAPI, getAllTeamsAPI } from "../services/api/teamAPI";
import { generateLocalTeamId } from "../utility/generateLocalTeamId";


function TeamListPage(props) {
    const { token, isLoggedIn } = userContext();

    async function handleClickGetTeamsButton() {
        // This button is needed so that changes arent overwritten on refresh? (if you loaded teams with page load)
        if (isLoggedIn() === false) {
            alert("Log in to access the server");
            props.setPage(ACCOUNT_PAGE);
            return;
        }


        // Warn the user about current server teams being overwritten (if there are any present)
        if (
            props.teams.filter(team => team.id > 0).length > 0 &&
            confirm("Warning: Server teams will be overwritten. Continue?") === false
        ) {
            return;
        }

        const serverTeams = await getAllTeamsAPI(token);

        if (serverTeams === undefined) {
            return alert("Failed to retrieve teams from server. Please try again");
        }

        props.setTeams(teams => {
            // replace only the server teams, not local teams
            const localTeams = teams.filter(team => team.id < 0);
            const newTeams = localTeams.concat(serverTeams);

            return newTeams;
        })
    }


    async function handleClickSaveTeamsButton() {
        if (isLoggedIn() === false) {
            alert("Log in to access the server");
            props.setPage(ACCOUNT_PAGE);
            return;
        }

        const serverTeams = await createUpdateTeamsAPI(props.teams, token);

        if (serverTeams === undefined) {
            return alert("Save failed. Please try again");
        }

        alert("Save Successful");
        props.setTeams(teams => serverTeams);
    }




    function handleClickNewTeamButton() {
        const newTeam = createNewTeam({id: generateLocalTeamId(props.teams)});  // Use negative id for new teams/pokemon

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
                {`Server Teams (${serverTeams.length})`}
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