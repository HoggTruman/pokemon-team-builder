import React from "react";
import TeamList from "../components/TeamListPage/TeamList";
import createNewTeam from "../models/teamFactory";
import { ACCOUNT_PAGE, TEAM_EDIT_PAGE } from "./constants/pageNames";
import { userContext } from "../context/userContext";
import { createTeamsAPI, getAllTeamsAPI } from "../services/api/teamAPI";
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

        const newServerTeams = await getAllTeamsAPI(token);

        if (newServerTeams === undefined) {
            return alert("Failed to retrieve teams from server. Please try again");
        }

        props.setServerTeams(teams => newServerTeams)
    }


    async function handleClickSaveLocalTeamsButton() {
        if (isLoggedIn() === false) {
            alert("Log in to access the server");
            props.setPage(ACCOUNT_PAGE);
            return;
        }

        if (props.localTeams.length === 0) {
            return;
        }

        const newServerTeams = await createTeamsAPI(props.localTeams, token);

        if (newServerTeams === undefined) {
            return alert("Save failed. Please try again");
        }

        alert("Save Successful");
        props.setServerTeams(teams => teams.concat(newServerTeams));
        props.setLocalTeams(teams => [])
    }




    function handleClickNewTeamButton() {
        const newTeam = createNewTeam({id: generateLocalTeamId(props.localTeams)});  // Use negative id for new teams/pokemon

        props.setLocalTeams(teams => teams.concat(newTeam));
        
        props.setActiveTeamId(newTeam.id);
        props.setPage(TEAM_EDIT_PAGE);
    }

    // Render 
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
                onClick={handleClickSaveLocalTeamsButton}
            >
                Save local teams to server
            </button>

            <h2>
                {`Server Teams (${props.serverTeams.length})`}
            </h2>
            <TeamList
                setPage={props.setPage}
                teams={props.serverTeams}
                setTeams={props.setServerTeams}
                setActiveTeamId={props.setActiveTeamId}
                data={props.data}
            />
            <div>
                {
                    props.serverTeams.length === 0? 
                        isLoggedIn()?
                            "Get your teams from the server, or save a local team!":
                            "Log in to retrieve your teams from the server!": 
                        ""
                }
            </div>

            <h2>
                {`Local Teams (${props.localTeams.length})`}
            </h2>
            <TeamList
                setPage={props.setPage}
                teams={props.localTeams}
                setTeams={props.setLocalTeams}
                setActiveTeamId={props.setActiveTeamId}
                data={props.data}
            />
            <div>
                {
                    props.localTeams.length === 0? 
                        isLoggedIn()?
                            "All your teams are saved to the server!":
                            "Create a new team to get started!": 
                        ""
                }
            </div>
        </>
    )
}



export default TeamListPage;