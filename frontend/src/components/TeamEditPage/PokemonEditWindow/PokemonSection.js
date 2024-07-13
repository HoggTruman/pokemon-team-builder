import React from "react";

import "./PokemonSection.css";

function PokemonSection(props) {
    return (
        <div id="pokemonSection">
            <img src="" alt="pokemon-img" />
            <div>type images?</div>

            <label htmlFor="pokemonInput">Pokemon</label>
            <input id="pokemonInput" type="text" name="pokemon"/>

            <label htmlFor="nicknameInput">Nickname</label>
            <input id="nicknameInput" type="text" name="nickname" placeholder={"pokemon name"} />
        </div>
    );
}

export default PokemonSection