import React from "react";

import { MOVE1_FIELD, MOVE2_FIELD, MOVE3_FIELD, MOVE4_FIELD } from "./constants/fieldNames";

import "./MovesSection.css";


function MovesSection(props) {
    function handleClickMoveInput(fieldName) {
        props.setActiveField(fieldName)
    }


    // Render
    return (
        <div id="movesSection">
            <label>Moves</label>
            <input 
                id="move1Input" 
                type="text" 
                name={MOVE1_FIELD}
                onClick={() => handleClickMoveInput(MOVE1_FIELD)}
            />
            <input 
                id="move2Input" 
                type="text" 
                name={MOVE2_FIELD}
                onClick={() => handleClickMoveInput(MOVE2_FIELD)}
            />
            <input 
                id="move3Input" 
                type="text" 
                name={MOVE3_FIELD}
                onClick={() => handleClickMoveInput(MOVE3_FIELD)}
            />
            <input 
                id="move4Input" 
                type="text" 
                name={MOVE4_FIELD}
                onClick={() => handleClickMoveInput(MOVE4_FIELD)}
            />
        </div>
    );
}

export default MovesSection;