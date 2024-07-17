import React from "react";


function PokemonOptionsRow(props) {

    return (
        <button className="row pokemon">
            <div className="col icon">
                <img
                    src=""
                    alt="icon"
                    className="optionsRowIcon"
                />
            </div>
            <div className="col name">{"name"}</div>
            <div className="col types">
                {"type images"}
            </div>
            <div className="col abilities">
                {"abilities"}
            </div>
            <div className="col stat">{"hp"}</div>
            <div className="col stat">{"atk"}</div>
            <div className="col stat">{"def"}</div>
            <div className="col stat">{"spatk"}</div>
            <div className="col stat">{"spdef"}</div>
            <div className="col stat">{"speed"}</div>
            <div className="col bst">{"total"}</div>
        </button>
    )
}

export default PokemonOptionsRow;