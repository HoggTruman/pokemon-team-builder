import React from "react";
import SelectPokemonButton from "./SelectPokemonButton";

import "./TeamEditMenu.css";

function TeamEditMenu(props) {

    let pokemonButtons = props.pokemonList.map(pokemon => (
        <SelectPokemonButton
            key="pokemon.id"
            pokemon={pokemon}
        />
    ));

    let addPokemonButton = (
        <div
            id="addPokemonButton"
        >
            <img
                src=""
                alt="+"
            />
            <p>Add Pokemon</p>
        </div>
    );

    return (
        <div
            id="teamEditMenu"
        >
            <button>{"< Teams"}</button>
            <div id="selectPokemonButtons">
                {pokemonButtons}
                {pokemonButtons.length < 6? addPokemonButton: null}
            </div>
        </div>
    )
}

export default TeamEditMenu;