import React from "react";
import PokemonOptionsRow from "./PokemonOptionsRow";

import "./OptionsTable.css"

function PokemonOptions(props) {
    let pokemonOptionsRows = props.pokemonList.map(pokemon => (
        <PokemonOptionsRow
            key={"pokemon.id"}
            pokemon={pokemon}
        />
    ))

    return (
        <table id="pokemonOptionsTable" className="optionsTable">
            <tr className="optionsHeaders">
                <th>{"(Icon)"}</th>
                <th>Name</th>
                <th>Types</th>
                <th>Abilities</th>
                <th>HP</th>
                <th>Atk</th>
                <th>Def</th>
                <th>SpAtk</th>
                <th>SpDef</th>
                <th>Speed</th>
                <th>BST</th>
            </tr>
            { pokemonOptionsRows }
        </table>
    );
}

export default PokemonOptions;