import React from "react";
import { damageCategoryImages, typeImages } from "../../../assets/assets";

function MoveOptionsRow(props) {

    return (
        <button 
            className="row move"
            onClick={props.handleClick}
        >
            <div className="col name">{props.move.identifier}</div>
            <div className="col type">
                <img
                    src={typeImages[props.move.type]}
                    alt={props.move.type}
                />
            </div>
            <div className="col category">
                <img
                    src={damageCategoryImages[props.move.damageClass]}
                    alt={props.move.damageClass}
                />
            </div>
            <div className="col stat">{props.move.power || "-"}</div>
            <div className="col stat">{props.move.accuracy || "-"}</div>
            <div className="col stat">{props.move.pp}</div>
            <div className="col effect">
                {
                    props.move.moveEffect
                        .replace('$effect_chance', props.move.moveEffectChance)
                }
            </div>
        </button>
    )
}

export default MoveOptionsRow;