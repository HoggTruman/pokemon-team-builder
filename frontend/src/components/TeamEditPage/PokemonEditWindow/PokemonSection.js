import React from "react";

import { POKEMON_FIELD } from "./constants/fieldNames";

import "./PokemonSection.css";


function PokemonSection(props) {

    function handleClickPokemonInput() {
        props.setActiveField(POKEMON_FIELD)
    }


    // Render
    return (
        <div id="pokemonSection">
            <img src="" alt="pokemon-img" />
            <div>type images?</div>

            <label htmlFor="pokemonInput">Pokemon</label>
            <input 
                id="pokemonInput" 
                type="text" 
                name={POKEMON_FIELD}
                onClick={handleClickPokemonInput}
            />

            <label htmlFor="nicknameInput">Nickname</label>
            <input id="nicknameInput" type="text" name="nickname" placeholder={"POKEMON NAME!!!!!!!!!!"} />
        </div>
    );
}

export default PokemonSection