import React from "react";

function MovesSection(props) {
    return (
        <div id="movesSection">
            <label>Moves</label>
            <input id="move1Input" type="text" name="move1"/>
            <input id="move2Input" type="text" name="move2"/>
            <input id="move3Input" type="text" name="move3"/>
            <input id="move4Input" type="text" name="move4"/>
        </div>
    );
}

export default MovesSection;