import React from "react";
import PokemonOptions from "./PokemonOptions";
import ItemOptions from "./ItemOptions";
import AbilityOptions from "./AbilityOptions";
import MoveOptions from "./MoveOptions";
import { ABILITY_FIELD, ITEM_FIELD, MOVE1_FIELD, MOVE2_FIELD, MOVE3_FIELD, MOVE4_FIELD, POKEMON_FIELD } from "../PokemonEditWindow/constants/fieldNames";

function OptionsWindow(props) {
    let optionsTable;
    let header;

    if (props.activeField == POKEMON_FIELD) {
        header = <p>Pokemon</p>;
        optionsTable = <PokemonOptions pokemonList={[1,2,3,4,5,6,7,8,9]}/>;
    } 
    else if (props.activeField == ITEM_FIELD) {
        header = <p>Items</p>;
        optionsTable = <ItemOptions itemList={[1,2,3,4,5,6,7,8,9]}/>;
    }
    else if (props.activeField == ABILITY_FIELD) {
        header = <p>Abilities</p>;
        optionsTable = <AbilityOptions abilityList={[1,2,3,4,5,6,7,8,9]}/>;
    }
    else if (
        props.activeField == MOVE1_FIELD ||
        props.activeField == MOVE2_FIELD ||
        props.activeField == MOVE3_FIELD ||
        props.activeField == MOVE4_FIELD         
    ) {
        header = <p>Moves</p>;
        optionsTable = <MoveOptions moveList={[1,2,3,4,5,6,7,8,9]} activeField={props.activeField}/>;
    }
    else {
        header = null;
        optionsTable = null;
    }

    return (
        <div id="OptionsWindow">
            {header}
            {optionsTable}
        </div>
    );
}

export default OptionsWindow;