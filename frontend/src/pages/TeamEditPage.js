import React from "react";
import TeamEditMenu from "../components/TeamEditPage/TeamEditMenu/TeamEditMenu";
import PokemonEditWindow from "../components/TeamEditPage/PokemonEditWindow/PokemonEditWindow";
import OptionsWindow from "../components/TeamEditPage/OptionsWindow/OptionsWindow";




function TeamEditPage(props) {


    return (
        <>
            <TeamEditMenu
                setPage
                pokemonList={[1,2,3]}
            />
            <PokemonEditWindow />
            <OptionsWindow activeField={"pokemon"} />
        </>
    )
}


export default TeamEditPage;