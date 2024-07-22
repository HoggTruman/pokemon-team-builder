import React from "react";
import PokemonOptions from "./PokemonOptions";
import ItemOptions from "./ItemOptions";
import AbilityOptions from "./AbilityOptions";
import MoveOptions from "./MoveOptions";
import { ABILITY_FIELD, ITEM_FIELD, MOVE1_FIELD, MOVE2_FIELD, MOVE3_FIELD, MOVE4_FIELD, POKEMON_FIELD } from "../PokemonEditWindow/constants/fieldNames";

function OptionsWindow(props) {
    let optionsTable;

    if (props.activeField == POKEMON_FIELD) {
        optionsTable = (
            <PokemonOptions 
                pokemonList={filterListByInput(props.data.pokemon, props.activePokemon.pokemonName)}
                setTeamEdit={props.setTeamEdit}
                activePokemon={props.activePokemon}
            />
        );
    } 
    else if (props.activeField == ITEM_FIELD) {
        optionsTable = (
            <ItemOptions 
                itemList={filterListByInput(props.data.items, props.activePokemon.itemName)}
                setTeamEdit={props.setTeamEdit}
                activePokemon={props.activePokemon}
            />
        );
    }
    else if (props.activeField == ABILITY_FIELD) {
        const abilities = props.data.pokemon.find(x => x.identifier == props.activePokemon.pokemonName)
            ?.abilities.map(abilityId => props.data.abilities.find(x => x.id == abilityId))
            || [];

        optionsTable = (
            <AbilityOptions 
                abilityList={filterListByInput(abilities, props.activePokemon.abilityName)}
                setTeamEdit={props.setTeamEdit}
                activePokemon={props.activePokemon}
            />
        );
    }
    else if (
        props.activeField == MOVE1_FIELD ||
        props.activeField == MOVE2_FIELD ||
        props.activeField == MOVE3_FIELD ||
        props.activeField == MOVE4_FIELD         
    ) {
        optionsTable = <MoveOptions moveList={[1,2,3,4,5,6,7,8,9]} activeField={props.activeField}/>;
    }
    else {
        optionsTable = null;
    }

    return (
        <div id="OptionsWindow">
            {optionsTable}
        </div>
    );
}

function filterListByInput(list, input) {
    const cleanInput = input.toLowerCase().trim();

    return list.filter(x => x.identifier.includes(cleanInput));
}



export default OptionsWindow;