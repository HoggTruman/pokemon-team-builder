import React from "react";

function AbilityOptionsRow(props) {

    return (
        <button 
            className="row ability"
            onClick={props.handleClick}
        >
            <div className="col name">
                {props.ability.identifier}
            </div>
            <div className="col effect">
                {props.ability.flavorText}
            </div>
        </button>
    )
}

export default AbilityOptionsRow;