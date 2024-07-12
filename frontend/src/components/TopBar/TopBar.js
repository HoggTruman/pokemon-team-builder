import React from "react";
import "./TopBar.css"
import AccountButtons from "./AccountButtons";

class TopBar extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div id="topbar">
                <h1>Team Builder</h1>
                <AccountButtons />
            </div>
        ) 
    }
}

export default TopBar;