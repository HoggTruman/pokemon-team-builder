import React from "react";
import AbilityOptionsRow from "./AbilityOptionsRow";

import "./OptionsTable.css";
import "./AbilityOptions.css";


function AbilityOptions(props) {
    let abilityOptionsRows = props.abilityList.map(ability => (
        <AbilityOptionsRow
            key={"ability.id"}
            ability={ability}
        />
    ));

    return (
        <div id="abilityOptionsTable" className="optionsTable">
            <div className="row ability header">
                <div className="col name">Ability</div>
                <div className="col effect">Effect</div>
            </div>
            { abilityOptionsRows }
        </div>
    );
}

export default AbilityOptions;