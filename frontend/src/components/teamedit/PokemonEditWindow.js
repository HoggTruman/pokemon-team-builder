import React from "react";
import StatsSection from "./StatsSection";

function PokemonEditWindow(props) {
    return (
        <div id="pokemonEditWindow">
            <div>
                <img src="" alt="pokemon-img" />
                <div>type images?</div>

                <label htmlFor="pokemonInput">Pokemon</label>
                <input id="pokemonInput" type="text" name="pokemon"/>
            </div>

            <div>
                <label htmlFor="nicknameInput">Nickname</label>
                <input id="nicknameInput" type="text" name="nickname" placeholder={"pokemon name"} />

                <label htmlFor="levelInput">Level</label>
                <input 
                    id="levelInput" 
                    type="number" 
                    name="level"
                    min={1}
                    max={100}
                    defaultValue={50}
                />

                <label htmlFor="genderInput">Gender</label>
                <select id="genderSelect" name="gender">
                    <option value="example-gender1">example-gender1</option>
                    <option value="example-gender2">example-gender2</option>
                </select>

                <label htmlFor="shinySelect">Shiny</label>
                <select id="shinySelect" name="shiny">
                    <option value={false}>No</option>
                    <option value={true}>Yes</option>
                </select>

                <label htmlFor="teraTypeSelect">Tera Type</label>
                <select id="teraTypeSelect" name="teraType">
                    <option value="example-type1">example-type1</option>
                    <option value="example-type2">example-type2</option>
                </select>
            </div>

            <div id="movesSection">
                <label>Moves</label>
                <input id="move1Input" type="text" name="move1"/>
                <input id="move2Input" type="text" name="move2"/>
                <input id="move3Input" type="text" name="move3"/>
                <input id="move4Input" type="text" name="move4"/>
            </div>

            <label htmlFor="itemInput">Item</label>
            <input id="itemInput" type="text" name="item"/>

            <label htmlFor="abilityInput">Pokemon</label>
            <input id="abilityInput" type="text" name="ability"/>

            <StatsSection />

            <button id="deletePokemonButton">Delete Pokemon</button>
        </div>
    )
}

export default PokemonEditWindow;