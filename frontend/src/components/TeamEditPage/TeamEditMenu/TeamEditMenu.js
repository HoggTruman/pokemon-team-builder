import React from "react";
import SelectPokemonButton from "./SelectPokemonButton";
import { TEAM_LIST_PAGE } from "../../../pages/constants/pageNames";
import createNewPokemonEdit from "../../../models/pokemonEditFactory";

import "./TeamEditMenu.css";


function TeamEditMenu(props) {
    
    function handleClickAddPokemonButton()
    {
        if (props.teamEdit.pokemon.length >= 6)
        {
            return;
        }

        const newTeamSlot = props.teamEdit.pokemon.length + 1;
            
        props.setTeamEdit(team => {
            team.pokemon.push(createNewPokemonEdit({ teamSlot: newTeamSlot }));

            return {...team};
        });

        props.setActiveTeamSlot(newTeamSlot);
    }


    function handleClickDeletePokemonButton() {
        if (props.teamEdit.pokemon.length == 1) {
            return;
        }
        
        props.setTeamEdit(team => {
            team = deletePokemonFromTeam(team, props.activeTeamSlot);

            return {...team};
        })


        props.setActiveTeamSlot(slot => Math.max(1, slot - 1));
        
        // MAY BE BETTER TO MAKE EVERY TEAM HAVE 6 POKEMON IN DB BUT MARK EACH AS ACTIVE OR NOT, THIS WAY THEY HAVE A CONSISTENT ID TO USE AND EDITING TEAMS WONT REQUIRE DELETING
    }



    // Render
    let pokemonButtons = props.teamEdit.pokemon.map(pokemon => (
        <SelectPokemonButton
            key={pokemon.id || `${pokemon.teamSlot}${Date.now()}`} // Probably a better way to get a unique key for new teams
            pokemon={pokemon} //{props.teamEdit.pokemon.find(x => x.teamSlot == teamSlot)}
            activeTeamSlot={props.activeTeamSlot}
            setActiveTeamSlot={props.setActiveTeamSlot}
            data={props.data}
        />
    ))

    // let pokemonButtons = props.teamEdit.pokemon.map(pokemon => (
    //     <SelectPokemonButton
    //         key={pokemon.id || `${pokemon.teamSlot}${Date.now()}`}  // Probably a better way to get a unique key for new teams
    //         pokemon={pokemon}
    //         activeTeamSlot={props.activeTeamSlot}
    //         setActiveTeamSlot={props.setActiveTeamSlot}
    //     />
    // ));

    let addPokemonButton = (
        <button
            id="addPokemonButton"
            className="menuButton"
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
                className="menuButton back"
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
                className="menuButton"
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
                className="menuButton"
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