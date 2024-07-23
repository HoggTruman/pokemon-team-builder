import React from "react";
import { pokemonIcons } from "../../../assets/assets";

import "./SelectPokemonButton.css";


function SelectPokemonButton(props) {
    function handleClick() {
        props.setActiveTeamSlot(props.pokemon.teamSlot);
    }

    function handleClassName() {
        let className = "menuButton pokemon";
        if (props.pokemon.teamSlot == props.activeTeamSlot) {
            className = className.concat(" ", " active");
        }

        return className;
    }


    function getPokemonData(pokemonName) {
        const cleanName = pokemonName.toLowerCase().trim();
        return props.data.pokemon.find(x => x.identifier == cleanName);
    }

    // Render
    const pokemonData = getPokemonData(props.pokemon.pokemonName);

    return (
        <button
            className={handleClassName()}
            onClick={handleClick}
        >
            <div className="iconFrame">
                <span className="iconHelper"></span>
                <img
                    src={pokemonData? pokemonIcons[pokemonData.identifier]: pokemonIcons["_unknown"]}
                    className="icon"  
                />
            </div>
            <p>{pokemonData? pokemonData.identifier: "???"}</p>
        </button>
        
    )
}

export default SelectPokemonButton;