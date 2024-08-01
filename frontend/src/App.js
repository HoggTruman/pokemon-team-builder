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
    const [serverTeams, setServerTeams] = useState([]);
    const [localTeams, setLocalTeams] = useState(getLocalStorageTeams() || [])
    const [activeTeamId, setActiveTeamId] = useState(0);

    // Fetch static data
    const data = staticData;

    // Update local storage
    useEffect(() => {
        setLocalStorageTeams(localTeams);
    }, [localTeams]);
  
    
    return (
        <>
            <UserProvider>
                <TopBar 
                    page={page}
                    setPage={setPage}
                    setServerTeams={setServerTeams}
                />
                <PageSelector 
                    page={page}
                    setPage={setPage}
                    serverTeams={serverTeams}
                    setServerTeams={setServerTeams}
                    localTeams={localTeams}
                    setLocalTeams={setLocalTeams}
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