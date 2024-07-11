import React from "react";
import TeamEditMenu from "../components/teamedit/TeamEditMenu";
import PokemonEditWindow from "../components/teamedit/PokemonEditWindow";
import DetailEditWindow from "../components/teamedit/DetailEditWindow";


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
                <DetailEditWindow />
                <div>Team Edit Page</div>
            </>
        )
    }
}



export default TeamEditPage;