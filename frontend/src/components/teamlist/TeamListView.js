import React from "react";
import TeamList from "./TeamList";


class TeamListView extends React.Component {
    constructor(props) {
        super(props)

    }

    render() {
        return (
            <>
                <h1>Team Builder</h1>
                <h2>Select a team or create a new one</h2>
                <TeamList 
                    teams={this.props.teams}
                />
            </>
        )
    }
}



export default TeamListView;