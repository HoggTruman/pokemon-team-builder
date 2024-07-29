import React, { useEffect, useState } from "react";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import PageSelector from "./components/PageSelector";
import TopBar from "./components/TopBar/TopBar";
import { TEAM_LIST_PAGE } from "./pages/constants/pageNames";


import createNewPokemon from "./models/pokemonFactory";
import createNewTeam from "./models/teamFactory";
import { fetchStaticData } from "./services/fetchStaticData";
import { UserProvider } from "./context/userContext";

import "./App.css";




// Fetch static data
const staticData = await fetchStaticData()



// App
function App() {
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
    const data = staticData;

    // useEffect(() => {
    //     async function fetchData() {
    //          use to fetch teams?? 
    //         const teams = await newGetAllAbilities();
    //         
    //     }

    //     fetchData();
    // }, []);
  
    
    return (
        <>
            <UserProvider>
                <TopBar 
                    page={page}
                    setPage={setPage}
                />
                <PageSelector 
                    page={page}
                    setPage={setPage}
                    teams={teams}
                    setTeams={setTeams}
                    activeTeamId={activeTeamId}
                    setActiveTeamId={setActiveTeamId}
                    data={data}
                />
            </UserProvider>
            <ToastContainer />
        </>
    )
}
  
export default App;