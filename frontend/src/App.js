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
import { getAllGenders } from "./api/genderAPI";

import createNewPokemon from "./models/pokemonFactory";
import createNewTeam from "./models/teamFactory";


import "./App.css";






function App(props) {
    const demoTeams = [
        createNewTeam({
            id: 1,
            teamName:"team1",
            pokemon: [
                createNewPokemon({
                    id: 1,
                    pokemonId: 6,
                    teamSlot: 1,
                    genderId: 1
                }),
                createNewPokemon({
                    id: 2,
                    pokemonId: 6,
                    teamSlot: 2
                }),
                createNewPokemon({
                    id: 3,
                    pokemonId: 3,
                    teamSlot: 3
                }),
                createNewPokemon({
                    id: 6,
                    pokemonId: 6,
                    teamSlot: 4
                }),
                createNewPokemon({
                    id: 9,
                    pokemonId: 9,
                    teamSlot: 5
                }),
                createNewPokemon({
                    id: 12,
                    pokemonId: 12,
                    teamSlot: 6
                }),
            ]
        }),
        createNewTeam({
            id: 2,
            teamName:"team2",
            pokemon: [
                createNewPokemon({
                    id: 10,
                    pokemonId: 10,
                    teamSlot: 1
                }),
            ]
        }),
        createNewTeam({
            id: 3,
            teamName:"team3",
            pokemon: [
                createNewPokemon({
                    id: 11,
                    pokemonId: 11,
                    teamSlot: 1
                }),
                createNewPokemon({
                    id: 22,
                    pokemonId: 22,
                    teamSlot: 2
                }),
            ]
        }),
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
    data.genders = getAllGenders();
    
  
    
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