import React, { useState } from "react";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import PageSelector from "./components/PageSelector";
import TopBar from "./components/TopBar/TopBar";
import { TEAM_LIST_PAGE } from "./pages/constants/pageNames";


import "./App.css";


function App(props) {
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

    const [page, setPage] = useState(TEAM_LIST_PAGE);
    const [teams, setTeams] = useState(demoTeams);
    const [activeTeamId, setActiveTeamId] = useState(0);

    
  
    
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
            />
            <ToastContainer />
        </>
    )
}
  
export default App;