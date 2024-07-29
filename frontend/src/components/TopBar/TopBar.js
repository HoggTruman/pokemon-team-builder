import React from "react";
import AccountButtons from "./AccountButtons";

import "./TopBar.css"


function TopBar(props)  {

    return (
        <div id="topbar">
            <h1>Team Builder</h1>
            <AccountButtons
                page={props.page}
                setPage={props.setPage}
            />
        </div>
    ) 

}

export default TopBar;