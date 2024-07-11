import React from "react";

import "./SelectPokemonButton.css";

function SelectPokemonButton(props) {

    // maybe use actual button instead of div??

    return (
        <div
            className="selectPokemonButton"
            onClick={() => "setActivePokemonStateToThisPokemon"}
        >
            <img
                src=""
                alt="pokemon icon"
                className="teamEditMenuIcon"  
            />
            <p>pokemon name</p>
        </div>
        
    )
}

export default SelectPokemonButton;