import React from "react";

import "./TeamInList.css";


class TeamInList extends React.Component {
    constructor(props) {
        super(props)

    }

    render() {
        return (
            <div 
                className="teamInList"
                key={this.props.id}
            >
                <div className="teamButton">
                    <p>TEAMNAME</p>
                    <p>pokemon icons??</p>
                </div>
                <button
                    onClick={() => "edit name window"}
                >
                    change name
                </button>
                <button
                    onClick={() => "confirm delete team"}
                >
                    delete
                </button>
            </div>
        )
    }
}


export default TeamInList;