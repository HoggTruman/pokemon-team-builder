import React from "react";
import PokemonOptions from "./PokemonOptions";
import ItemOptions from "./ItemOptions";
import AbilityOptions from "./AbilityOptions";
import MoveOptions from "./MoveOptions";

function OptionsWindow(props) {
    let optionsTable;
    let header;

    if (props.activeField == "pokemon") {
        optionsTable = <PokemonOptions pokemonList={[1,2,3,4,5,6,7,8,9]}/>;
        header = <p>Pokemon</p>;
    } 
    else if (props.activeField == "item") {
        optionsTable = <ItemOptions itemList={[1,2,3,4,5,6,7,8,9]}/>;
        header = <p>Items</p>;
    }
    else if (props.activeField == "ability") {
        optionsTable = <AbilityOptions abilityList={[1,2,3,4,5,6,7,8,9]}/>;
        header = <p>Abilities</p>;
    }
    else if (props.activeField == "move") {
        optionsTable = <MoveOptions moveList={[1,2,3,4,5,6,7,8,9]}/>;
        header = <p>Moves</p>;
    }
    else {
        optionsTable = null;
        header = null;
    }

    return (
        <div id="OptionsWindow">
            {header}
            {optionsTable}
        </div>
    );
}

export default OptionsWindow;