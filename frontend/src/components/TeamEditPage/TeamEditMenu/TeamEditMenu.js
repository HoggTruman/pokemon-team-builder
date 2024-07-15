import React from "react";
import SelectPokemonButton from "./SelectPokemonButton";

import "./TeamEditMenu.css";

function TeamEditMenu(props) {

    function handleClickAddPokemonButton()
    {
        if (props.team.pokemon.length >= 6)
        {
            return;
        }

        const newTeamSlot = props.team.pokemon.length + 1;
            
        props.setTeams(teams => {
            let team = teams.find(x => x.id == props.team.id);
            team.pokemon.push(
                {
                    pokemonId: 0,  // REPLACE THIS WITH A GENERIC POKEMON MODEL AND SET TEAMSLOT IN IT
                    teamSlot: newTeamSlot
                }
            )

            return [...teams];
        });

        props.setActivePokemonSlot(newTeamSlot);
    }


    function handleClickDeletePokemonButton() {
        if (props.team.pokemon.length == 1) {
            return;
        }
        
        props.setTeams(teams => {
            let team = teams.find(x => x.id == props.team.id);
            team = deletePokemonFromTeam(team, props.activePokemonSlot);

            return [...teams]
        })


        props.setActivePokemonSlot(slot => Math.max(1, slot - 1));
        
        // MAY BE BETTER TO MAKE EVERY TEAM HAVE 6 POKEMON IN DB BUT MARK EACH AS ACTIVE OR NOT, THIS WAY THEY HAVE A CONSISTENT ID TO USE AND EDITING TEAMS WONT REQUIRE DELETING
    }



    // Render

    let pokemonButtons = props.team.pokemon.map(pokemon => (
        <SelectPokemonButton
            key="pokemon.id?!?!??!?!"
            pokemon={pokemon}
            activePokemonSlot={props.activePokemonSlot}
            setActivePokemonSlot={props.setActivePokemonSlot}
        />
    ));

    let addPokemonButton = (
        <button
            id="addPokemonButton"
            onClick={handleClickAddPokemonButton}
        >
            <img
                src=""
                alt="+"
            />
            <p>Add Pokemon</p>
        </button>
    );

    return (
        <div id="teamEditMenu">
            <button
                onClick={() => props.setPage("team_list")}
            >
                {"< Teams"}
            </button>

            <div id="selectPokemonButtons">
                {pokemonButtons}
                {pokemonButtons.length < 6? addPokemonButton: null}
            </div>

            <button 
                id="deletePokemonButton"
                onClick={handleClickDeletePokemonButton}
            >
                <img
                    src=""
                    alt="del"
                />
                <p>delete current</p>
            </button>
        </div>
    )
}




// Component Logic (Separated for testing)

/**
 * 
 * @param {object} team 
 * @param {int} deleteSlot 
 * @returns A shallow copy of the modified team object
 * 
 * Note: this modifies the team passed in
 */
export function deletePokemonFromTeam(team, deleteSlot) {
    if (team.pokemon.length == 1) {
        return team;
    }

    team.pokemon = team.pokemon.filter(pokemon => pokemon.teamSlot != deleteSlot);
    for (const pokemon of team.pokemon) {
        if (pokemon.teamSlot > deleteSlot) {
            pokemon.teamSlot -= 1;
        }
    }

    return team
}




export default TeamEditMenu;