import React from "react";
import TeamList from "../components/teamlist/TeamList";


class TeamListPage extends React.Component {
    constructor(props) {
        super(props)

    }

    render() {
        return (
            <>
                <h1>Teams</h1>
                <h2>Select a team or create a new one</h2>
                <button
                    onClick={() => this.props.setPage("team_edit")}
                >
                    New Team
                </button>
                <button>Get teams from server</button>
                <TeamList
                    
                />
            </>
        )
    }
}



export default TeamListPage;