import React from "react";
import TeamListPage from "../pages/TeamListPage";
import TeamEditPage from "../pages/TeamEditPage";

class PageSelector extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (this.props.page == "team_list") {
            return (
                <TeamListPage 
                    setPage={this.props.setPage}
                />
            );
        }
        else if (this.props.page == "team_edit") {
            return (
                <TeamEditPage
                    setPage={this.props.setPage}
                />
            );
        }
            
    }
}

export default PageSelector;