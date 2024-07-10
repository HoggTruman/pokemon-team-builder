import React from "react";
import TeamInList from "./TeamInList";


class TeamList extends React.Component {
    constructor(props) {
        super(props)

    }

    render() {
        const teamRender = this.props.teams.map((team, teamIndex) => (
            <TeamInList 
                key={team.id}
            />
        ));

        return (
            <section id="team-list">

            </section>
        )
    }
}



export default TeamList;