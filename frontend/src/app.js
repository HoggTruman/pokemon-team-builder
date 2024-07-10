import React from "react";
import TeamListView from "./components/teamlist/TeamListView";
import TeamEditView from "./components/teamedit/TeamEditView";

class App extends React.Component {
    constructor(props) {
        super(props);

        const defaultState = {
            view: "team_list",
            teams: []
        };

        this.state = defaultState;
    }
  
    render() {
        if (this.state.view == "team_list")
            return (
                <TeamListView 
                    teams={this.state.teams}
                />
            );
        else if (this.state.view == "team_edit")
            return <TeamEditView />;
    }
}
  
export default App;