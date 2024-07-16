import createNewPokemon from "./pokemonFactory";


function createNewTeam(id = null, teamName = "new team") {
    return (
        {
            id: id,
            teamName: teamName,
            pokemon: [
                createNewPokemon()
            ]
        }
    );
}


export default createNewTeam;

