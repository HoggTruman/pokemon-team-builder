import React from "react";
import AbilityOptionsRow from "./AbilityOptionsRow";

import "./OptionsTable.css";
import "./AbilityOptions.css";


function AbilityOptions(props) {
    function handleClickOptionRow(identifier) {
        props.setTeamEdit(team => {
            props.activePokemon.abilityName = identifier;
            return {...team};
        })
    }


    // Render
    let abilityOptionsRows = props.abilityList.map(ability => (
        <AbilityOptionsRow
            key={ability.id}
            ability={ability}
            handleClick={() => handleClickOptionRow(ability.identifier)}
        />
    ));

    if (abilityOptionsRows.length === 0) {
        abilityOptionsRows = <div className="noMatches">No Abilities Found</div>
    }

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