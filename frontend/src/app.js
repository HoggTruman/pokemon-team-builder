import React from "react";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import PageSelector from "./components/PageSelector";
import TopBar from "./components/Header";

class App extends React.Component {
    constructor(props) {
        super(props);

        const defaultState = {
            page: "team_list",
            teams: []
        };

        this.state = defaultState;
    }
  
    render() {
        return (
            <>
                <TopBar />
                <PageSelector page={this.state.page}/>
                <ToastContainer />
            </>
        )
    }
}
  
export default App;