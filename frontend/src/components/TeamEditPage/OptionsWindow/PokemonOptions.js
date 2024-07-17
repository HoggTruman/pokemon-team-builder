import React from "react";
import PokemonOptionsRow from "./PokemonOptionsRow";

import "./OptionsTable.css";
import "./PokemonOptions.css";

function PokemonOptions(props) {
    let pokemonOptionsRows = props.pokemonList.map(pokemon => (
        <PokemonOptionsRow
            key={"pokemon.id"}
            pokemon={pokemon}
        />
    ));

    return (
        <div id="pokemonOptionsTable" className="optionsTable">
            <div className="row pokemon header">
                <div className="col icon">{"(Icon)"}</div>
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