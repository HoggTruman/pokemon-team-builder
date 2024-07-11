import React, { useState } from "react";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import PageSelector from "./components/PageSelector";
import TopBar from "./components/TopBar";

import "./App.css";

function App(props) {
    const defaultState = {
        page: "team_list",
        teams: []
    };

    const [page, setPage] = useState(defaultState.page);


  
    
    return (
        <>
            <TopBar />
            <PageSelector 
                page={page}
                setPage={setPage}
            />
            <ToastContainer />
        </>
    )
}
  
export default App;