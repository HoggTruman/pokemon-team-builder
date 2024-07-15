import React, { useState } from "react";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import PageSelector from "./components/PageSelector";


import "./App.css";
import TopBar from "./components/TopBar/TopBar";

function App(props) {
    const defaultState = {
        page: "team_list",
        teams: []
    };

    const demoTeams = [
        {
            id: 1,
            teamName:"team1",
            pokemon: [
                {
                    pokemonId: 1,
                    teamSlot: 1
                },
                {
                    pokemonId: 2,
                    teamSlot: 2
                },
            ]
        },
        {
            id: 2,
            teamName:"team2",
            pokemon: [
                {
                    pokemonId: 10,
                    teamSlot: 1
                },
            ]
        },
        {
            id: 3,
            teamName:"team3",
            pokemon: [
                {
                    pokemonId: 11,
                    teamSlot: 1
                },
                {
                    pokemonId: 22,
                    teamSlot: 2
                },
            ]
        },
    ];

    const [page, setPage] = useState(defaultState.page);
    const [teams, setTeams] = useState(demoTeams);
    const [activeTeamId, setActiveTeamId] = useState(0);
    const [activePokemonSlot, setActivePokemonSlot] = useState(1); // 1-based indexing currently

    
  
    
    return (
        <>
            <TopBar />
            <PageSelector 
                page={page}
                setPage={setPage}
                teams={teams}
                setTeams={setTeams}
                activeTeamId={activeTeamId}
                setActiveTeamId={setActiveTeamId}
                activePokemonSlot={activePokemonSlot}
                setActivePokemonSlot={setActivePokemonSlot}
            />
            <ToastContainer />
            <h1>{activePokemonSlot}</h1>
        </>
    )
}
  
export default App;