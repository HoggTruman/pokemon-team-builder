import React from "react";

function DetailsSection(props) {
    return (
        <div id="detailsSection">
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

            <label htmlFor="itemInput">Item</label>
            <input id="itemInput" type="text" name="item"/>

            <label htmlFor="abilityInput">Ability</label>
            <input id="abilityInput" type="text" name="ability"/>
        </div>
    );
}

export default DetailsSection