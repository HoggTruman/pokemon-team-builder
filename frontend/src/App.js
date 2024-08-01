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
import { getLocalStorageTeams, setLocalStorageTeams } from "./utility/teamStorage";




// Fetch static data
const staticData = await fetchStaticData()



// App
function App() {
    const demoTeams = [
        createNewTeam({
            id: -1,
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
                    pokemonId: 9,
                    teamSlot: 2
                }),
                createNewPokemon({
                    id: 3,
                    pokemonId: 3,
                    teamSlot: 3
                }),
            ]
        })
    ];

    const [page, setPage] = useState(TEAM_LIST_PAGE);
    const [teams, setTeams] = useState(getLocalStorageTeams() || []);
    const [activeTeamId, setActiveTeamId] = useState(0);

    // Fetch static data
    const data = staticData;

    // Update local storage
    useEffect(() => {
        const localTeams = teams.filter(team => team.id < 0);
        setLocalStorageTeams(localTeams);
    }, [teams]);
  
    
    return (
        <>
            <UserProvider>
                <TopBar 
                    page={page}
                    setPage={setPage}
                    setTeams={setTeams}
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