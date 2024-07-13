import React from "react";
import TeamInList from "./TeamInList";


function TeamList(props) {


    const TEAMS = [
        {
            teamName:"team1",
            pokemon: [
                {
                    pokemonId: 1
                },
                {
                    pokemonId: 2
                },
            ]
        },
        {
            teamName:"team2",
            pokemon: [
                {
                    pokemonId: 10
                },
            ]
        },
        {
            teamName:"team3",
            pokemon: [
                {
                    pokemonId: 11
                },
                {
                    pokemonId: 22
                },
            ]
        },
    ];


    // render
    let teamRender = TEAMS.map((team, teamIndex) => (
        <TeamInList 
            key={"TEAMID"}
            team={team}
            setPage={props.setPage}
        />
    ));

    return (
        <div id="teamList">
            {teamRender}
        </div>
    );
}



export default TeamList;