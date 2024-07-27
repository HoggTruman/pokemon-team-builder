import React from "react";
import PokemonOptionsRow from "./PokemonOptionsRow";

import "./OptionsTable.css";
import "./PokemonOptions.css";

function PokemonOptions(props) {
    function handleClickOptionRow(identifier) {
        props.setTeamEdit(team => {
            props.activePokemon.pokemonName = identifier;
            return {...team};
        })
    }

    // Render
    let pokemonOptionsRows = props.pokemonList.map(pokemon => (
        <PokemonOptionsRow
            key={pokemon.id}
            pokemon={pokemon}
            handleClick={() => handleClickOptionRow(pokemon.identifier)}
            data={props.data}
        />
    ));

    if (pokemonOptionsRows.length === 0) {
        pokemonOptionsRows = <div className="noMatches">No Pokemon Found</div>
    }

    return (
        <div id="pokemonOptionsTable" className="optionsTable">
            <div className="row pokemon header">
                <div className="col icon"></div>
                <div className="col name">Pokemon</div>
                <div className="col types">Types</div>
                <div className="col abilities">Abilities</div>
                <div className="col stat">HP</div>
                <div className="col stat">Atk</div>
                <div className="col stat">Def</div>
                <div className="col stat">SpAtk</div>
                <div className="col stat">SpDef</div>
                <div className="col stat">Speed</div>
                <div className="col bst">BST</div>
            </div>
            { pokemonOptionsRows }
        </div>
    );
}

export default PokemonOptions;