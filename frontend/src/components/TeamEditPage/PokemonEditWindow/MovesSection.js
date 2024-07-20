import React from "react";

import { MOVE1_FIELD, MOVE2_FIELD, MOVE3_FIELD, MOVE4_FIELD } from "./constants/fieldNames";

import "./MovesSection.css";


function MovesSection(props) {
    function handleClickMoveInput(fieldName) {
        props.setActiveField(fieldName)
    }

    function handleChangeMoveInput(e, teamEditKey) {
        props.setTeamEdit(team => {
            props.activePokemon[teamEditKey] = e.target.value;
            return {...team};
        })
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
                onChange={e => handleChangeMoveInput(e, "move1Name")}
                value={props.activePokemon.move1Name}
            />
            <input 
                id="move2Input"
                type="text"
                name={MOVE2_FIELD}
                onClick={() => handleClickMoveInput(MOVE2_FIELD)}
                onChange={e => handleChangeMoveInput(e, "move2Name")}
                value={props.activePokemon.move2Name}
            />
            <input 
                id="move3Input"
                type="text"
                name={MOVE3_FIELD}
                onClick={() => handleClickMoveInput(MOVE3_FIELD)}
                onChange={e => handleChangeMoveInput(e, "move3Name")}
                value={props.activePokemon.move3Name}
            />
            <input 
                id="move4Input"
                type="text"
                name={MOVE4_FIELD}
                onClick={() => handleClickMoveInput(MOVE4_FIELD)}
                onChange={e => handleChangeMoveInput(e, "move4Name")}
                value={props.activePokemon.move4Name}
            />
        </div>
    );
}

export default MovesSection;