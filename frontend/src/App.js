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

    const [page, setPage] = useState(defaultState.page);
    const [teams, setTeams] = useState(demoTeams);

    
  
    
    return (
        <>
            <TopBar />
            <PageSelector 
                page={page}
                setPage={setPage}
                teams={teams}
            />
            <ToastContainer />
        </>
    )
}
  
export default App;