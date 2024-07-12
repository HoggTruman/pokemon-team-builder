import React from "react";
import TeamEditMenu from "../components/teamedit/TeamEditMenu";
import PokemonEditWindow from "../components/teamedit/PokemonEditWindow";
import OptionsWindow from "../components/teamedit/OptionsWindow/OptionsWindow";



class TeamEditPage extends React.Component {
    constructor(props) {
        super(props)

    }

    render() {
        return (
            <>
                <TeamEditMenu
                    pokemonList={[1,2,3]}
                />
                <PokemonEditWindow />
                <OptionsWindow activeField={"pokemon"} />
            </>
        )
    }
}



export default TeamEditPage;