import React from "react";
import TeamInList from "./TeamInList";


class TeamList extends React.Component {
    constructor(props) {
        super(props)

    }

    render() {
        const TEAMS = [
            {},
        ];

        let teamRender = TEAMS.map((team, teamIndex) => (
            <TeamInList 
                key={"TEAMID"}
            />
        ));

        return (
            <div id="team-list">
                {teamRender}
            </div>
        )
    }
}



export default TeamList;