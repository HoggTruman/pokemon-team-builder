import React from "react";
import SelectPokemonButton from "./SelectPokemonButton";

import "./TeamEditMenu.css";
import createNewPokemon from "../../../models/pokemonFactory";
import { TEAM_LIST_PAGE } from "../../../pages/constants/pageNames";

function TeamEditMenu(props) {
    
    function handleClickAddPokemonButton()
    {
        if (props.teamEdit.pokemon.length >= 6)
        {
            return;
        }

        const newTeamSlot = props.teamEdit.pokemon.length + 1;
            
        props.setTeamEdit(team => {
            team.pokemon.push(createNewPokemon(newTeamSlot));

            return {...team};
        });

        props.setActivePokemonSlot(newTeamSlot);
    }


    function handleClickDeletePokemonButton() {
        if (props.teamEdit.pokemon.length == 1) {
            return;
        }
        
        props.setTeamEdit(team => {
            team = deletePokemonFromTeam(team, props.activePokemonSlot);

            return {...team};
        })


        props.setActivePokemonSlot(slot => Math.max(1, slot - 1));
        
        // MAY BE BETTER TO MAKE EVERY TEAM HAVE 6 POKEMON IN DB BUT MARK EACH AS ACTIVE OR NOT, THIS WAY THEY HAVE A CONSISTENT ID TO USE AND EDITING TEAMS WONT REQUIRE DELETING
    }



    // Render

    let pokemonButtons = props.teamEdit.pokemon.map(pokemon => (
        <SelectPokemonButton
            key={pokemon.id || `${pokemon.teamSlot}${Date.now()}`}  // Probably a better way to get a unique key for new teams
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
                onClick={() => props.setPage(TEAM_LIST_PAGE)}  // GIVE WARNING FOR UNSAVED CHANGES, ASK IF THEY WANT TO SAVE
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
            <button
                id="saveTeamButton"
            >
                Save Changes
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