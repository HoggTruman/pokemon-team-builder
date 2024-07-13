import React from "react";

import "./DetailsSection.css";

function DetailsSection(props) {
    return (
        <div id="detailsSection">
            <div className="row">
                <div className="field">
                    <label htmlFor="levelInput" className="side">Level</label>
                    <input 
                        id="levelInput" 
                        type="number" 
                        name="level"
                        min={1}
                        max={100}
                        defaultValue={50}
                    />
                </div>

                <div className="field">
                    <label htmlFor="genderInput" className="side">Gender</label>
                    <select id="genderSelect" name="gender">
                        <option value="example-gender1">example-gender1</option>
                        <option value="example-gender2">example-gender2</option>
                    </select>
                </div>
            </div>


            <div className="row">
                <div className="field">
                    <label htmlFor="shinySelect" className="side">Shiny</label>
                    <select id="shinySelect" name="shiny">
                        <option value={false}>No</option>
                        <option value={true}>Yes</option>
                    </select>
                </div>

                <div className="field">
                    <label htmlFor="teraTypeSelect" className="side">Tera Type</label>
                    <select id="teraTypeSelect" name="teraType">
                        <option value="example-type1">example-type1</option>
                        <option value="example-type2">example-type2</option>
                    </select>
                </div>
            </div>


            <div className="row">
                <div className="field">
                    <label htmlFor="itemInput" className="above">Item</label>
                    <input id="itemInput" type="text" name="item"/>
                </div>

                <div className="field">
                    <label htmlFor="abilityInput" className="above">Ability</label>
                    <input id="abilityInput" type="text" name="ability"/>
                </div>
            </div>
        </div>
    );
}

export default DetailsSection