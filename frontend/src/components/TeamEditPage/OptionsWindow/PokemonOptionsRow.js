import React from "react";
import { pokemonIcons, typeImages } from "../../../assets/assets";


function PokemonOptionsRow(props) {

    return (
        <button 
            className="row pokemon"
            onClick={props.handleClick}
        >
            <div className="col icon">
                <img
                    src={pokemonIcons[props.pokemon.identifier]}
                    alt="icon"
                    className="pokemonIcon"
                />
            </div>
            <div className="col name">{props.pokemon.identifier}</div>
            <div className="col types">
                {
                    props.pokemon.types.map(type => (
                        <img
                            key={type}
                            src={typeImages[type]}
                            alt={type}
                        />
                    ))
                }
            </div>
            <div className="col abilities">
                {
                    props.pokemon.abilities.map((ability, index) => (
                        <span key={index}>
                            {ability.identifier}
                        </span>
                    ))
                }
            </div>
            <div className="col stat">{props.pokemon.baseStats.hp}</div>
            <div className="col stat">{props.pokemon.baseStats.attack}</div>
            <div className="col stat">{props.pokemon.baseStats.defense}</div>
            <div className="col stat">{props.pokemon.baseStats.specialAttack}</div>
            <div className="col stat">{props.pokemon.baseStats.specialDefense}</div>
            <div className="col stat">{props.pokemon.baseStats.speed}</div>
            <div className="col bst">{calcBST(props.pokemon.baseStats)}</div>
        </button>
    )
}



function calcBST(baseStats) {
    return Object.values(baseStats).reduce((a, b) => a + b, 0);
}



export default PokemonOptionsRow;