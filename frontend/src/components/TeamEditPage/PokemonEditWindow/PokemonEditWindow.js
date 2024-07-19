import React from "react";

import PokemonSection from "./PokemonSection";
import StatsSection from "./StatsSection";


import "./PokemonEditWindow.css";
import DetailsSection from "./DetailsSection";
import MovesSection from "./MovesSection";



function PokemonEditWindow(props) {
    return (
        <div id="pokemonEditWindow">
            <PokemonSection 
                activePokemon={props.activePokemon}
                setActiveField={props.setActiveField}
                teamEdit={props.teamEdit}
                setTeamEdit={props.setTeamEdit}
                data={props.data}
            />

            <DetailsSection
                activePokemon={props.activePokemon}
                setActiveField={props.setActiveField}
                teamEdit={props.teamEdit}
                setTeamEdit={props.setTeamEdit}
                data={props.data}
            />

            <MovesSection
                setActiveField={props.setActiveField}
            />

            <StatsSection 
                setActiveField={props.setActiveField}
            />
        </div>
    )
}

export default PokemonEditWindow;