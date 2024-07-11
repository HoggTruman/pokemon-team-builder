import React from "react";

function SelectPokemonButton(props) {


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