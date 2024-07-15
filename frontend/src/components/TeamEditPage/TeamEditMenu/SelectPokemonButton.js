import React from "react";

import "./SelectPokemonButton.css";

function SelectPokemonButton(props) {
    function handleClick() {
        props.setActivePokemonSlot(props.pokemon.teamSlot);
    }

    function handleClassName() {
        let className = "selectPokemonButton";
        if (props.pokemon.teamSlot == props.activePokemonSlot) {
            className = className.concat(" ", " active");
        }

        return className;
    }


    return (
        <button
            className={handleClassName()}
            onClick={handleClick}
        >
            <img
                src=""
                alt="pokemon icon"
                className="teamEditMenuIcon"  
            />
            <p>pokemon name</p>
        </button>
        
    )
}

export default SelectPokemonButton;