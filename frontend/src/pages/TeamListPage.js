import React from "react";
import TeamList from "../components/TeamListPage/TeamList";


function TeamListPage(props) {


    return (
        <>
            <h1>Teams</h1>
            <h2>Select a team or create a new one</h2>
            <button
                onClick={() => props.setPage("team_edit")}
            >
                New Team
            </button>
            <button>Get teams from server/ save teams to server</button>
            <TeamList
                setPage={props.setPage}
            />
        </>
    )
}



export default TeamListPage;