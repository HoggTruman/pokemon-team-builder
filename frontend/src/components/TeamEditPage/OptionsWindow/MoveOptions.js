import React from "react";
import MoveOptionsRow from "./MoveOptionsRow";


import "./OptionsTable.css";
import "./MoveOptions.css"
import { MOVE1_FIELD, MOVE2_FIELD, MOVE3_FIELD, MOVE4_FIELD } from "../PokemonEditWindow/constants/fieldNames";


function MoveOptions(props) {
    function handleClickOptionRow(identifier) {
        props.setTeamEdit(team => {
            switch (props.activeField) {
                case MOVE1_FIELD:
                    props.activePokemon.move1Name = identifier;
                    break;
                case MOVE2_FIELD:
                    props.activePokemon.move2Name = identifier;
                    break;
                case MOVE3_FIELD:
                    props.activePokemon.move3Name = identifier;
                    break;
                case MOVE4_FIELD:
                    props.activePokemon.move4Name = identifier;
                    break;
            }
            
            return {...team};
        })
    }

    let moveOptionsRows = props.moveList.map(move => (
        <MoveOptionsRow
            key={move.id}
            move={move}
            handleClick={() => handleClickOptionRow(move.identifier)}
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