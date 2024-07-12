import React from "react";
import AbilityOptionsRow from "./AbilityOptionsRow";

function AbilityOptions(props) {
    let abilityOptionsRows = props.abilityList.map(ability => (
        <AbilityOptionsRow
            key={"ability.id"}
            ability={ability}
        />
    ))

    return (
        <table id="abilityOptionsTable" className="optionsTable">
            <tr className="optionsHeaders">
                <th>Ability</th>
                <th>Effect</th>
            </tr>
            { abilityOptionsRows }
        </table>
    );
}

export default AbilityOptions;