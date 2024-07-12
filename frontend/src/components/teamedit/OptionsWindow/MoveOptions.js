import React from "react";
import MoveOptionsRow from "./MoveOptionsRow";

function MoveOptions(props) {
    let moveOptionsRows = props.moveList.map(move => (
        <MoveOptionsRow
            key={"move.id"}
            move={move}
        />
    ))

    return (
        <table id="moveOptionsTable" className="optionsTable">
            <tr className="optionsHeaders">
                <th>Name</th>
                <th>Type</th>
                <th>Category</th>
                <th>Power</th>
                <th>Accuracy</th>
                <th>PP</th>
                <th>Effect</th>
            </tr>
            { moveOptionsRows }
        </table>
    );
}

export default MoveOptions;