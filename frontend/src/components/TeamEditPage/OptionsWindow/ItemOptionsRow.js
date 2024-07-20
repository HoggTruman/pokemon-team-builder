import React from "react";
import { itemIcons } from "../../../assets/assets";

function ItemOptionsRow(props) {

    return (
        <button 
            className="row item"
            onClick={props.handleClick}
        >
            <div className="col icon">
                <img
                    src={itemIcons[props.item.identifier]}
                    alt="icon"
                    className="itemIcon"
                />
            </div>
            <div className="col name">
                {props.item.identifier}
            </div>
            <div className="col effect">
                {props.item.effect}
            </div>
        </button>
    )
}

export default ItemOptionsRow;