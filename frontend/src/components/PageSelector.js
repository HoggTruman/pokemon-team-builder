import React from "react";
import TeamListPage from "../pages/TeamListPage";
import TeamEditPage from "../pages/TeamEditPage";

class PageSelector extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (this.props.page == "team_list") {
            return <TeamListPage />;
        }
        else if (this.props.page == "team_edit") {
            return <TeamEditPage />;
        }
            
    }
}

export default PageSelector;