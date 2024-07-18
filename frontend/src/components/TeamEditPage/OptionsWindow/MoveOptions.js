import React from "react";
import MoveOptionsRow from "./MoveOptionsRow";


import "./OptionsTable.css";
import "./MoveOptions.css"


function MoveOptions(props) {
    let moveOptionsRows = props.moveList.map(move => (
        <MoveOptionsRow
            key={"move.id"}
            move={move}
        />
    ))

    return (
        <div id="moveOptionsTable" className="optionsTable">
            <div className="row move header">
                <div className="col name">Name</div>
                <div className="col type">Type</div>
                <div className="col category">Cat</div>
                <div className="col stat">Pow</div>
                <div className="col stat">Acc</div>
                <div className="col stat">PP</div>
                <div className="col effect">Effect</div>
            </div>
            { moveOptionsRows }
        </div>
    );
}

export default MoveOptions;