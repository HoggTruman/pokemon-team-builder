import React, { useState } from "react";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import PageSelector from "./components/PageSelector";
import TopBar from "./components/TopBar/TopBar";
import { TEAM_LIST_PAGE } from "./pages/constants/pageNames";

import { getAllPokemon } from "./api/pokemonAPI";
import { getAllItems } from "./api/itemAPI";
import { getAllAbilities } from "./api/abilityAPI";
import { getAllTypes } from "./api/typeAPI";
import { getAllNatures } from "./api/natureAPI";
import { getAllMoves } from "./api/moveAPI";


import "./App.css";




function App(props) {
    const demoTeams = [
        {
            id: 1,
            teamName:"team1",
            pokemon: [
                {
                    pokemonId: 1,
                    teamSlot: 1,
                    genderId: "female"
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

    // Fetch static data
    const data = {};
    data.pokemon = getAllPokemon();
    data.items = getAllItems();
    data.abilities = getAllAbilities();
    data.moves = getAllMoves();
    data.types = getAllTypes();
    data.natures = getAllNatures();
    
  
    
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
                data={data}
            />
            <ToastContainer />
        </>
    )
}
  
export default App;