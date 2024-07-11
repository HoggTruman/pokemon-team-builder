import React from "react";
import SelectPokemonButton from "./SelectPokemonButton";

function TeamEditMenu(props) {

    let pokemonButtons = props.pokemonList.map(pokemon => (
        <SelectPokemonButton
            key="pokemon.id"
            pokemon={pokemon}
        />
    ));

    let addPokemonButton = (
        <div
            className="addPokemonButton"
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
            <div className="selectPokemonButtons">
                {pokemonButtons}
                {pokemonButtons.length < 6? addPokemonButton: null}
            </div>
        </div>
    )
}

export default TeamEditMenu;