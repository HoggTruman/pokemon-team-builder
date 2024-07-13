import React from "react";

import PokemonSection from "./PokemonSection";
import StatsSection from "./StatsSection";


import "./PokemonEditWindow.css";
import DetailsSection from "./DetailsSection";
import MovesSection from "./MovesSection";



function PokemonEditWindow(props) {
    return (
        <div id="pokemonEditWindow">
            <PokemonSection />

            <DetailsSection />

            <MovesSection />

            <StatsSection />
        </div>
    )
}

export default PokemonEditWindow;