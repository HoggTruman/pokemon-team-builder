import React from "react";
import ItemOptionsRow from "./ItemOptionsRow";

import "./OptionsTable.css";
import "./ItemOptions.css";

function ItemOptions(props) {
    function handleClickOptionRow(identifier) {
        props.setTeamEdit(team => {
            props.activePokemon.itemName = identifier;
            return {...team};
        })
    }

    // Render
    let itemOptionsRows = props.itemList.map(item => (
        <ItemOptionsRow
            key={item.id}
            item={item}
            handleClick={() => handleClickOptionRow(item.identifier)}
        />
    ));

    return (
        <div id="itemOptionsTable" className="optionsTable">
            <div className="row item header">
                <div className="col icon"></div>
                <div className="col name">Item</div>
                <div className="col effect">Effect</div>
            </div>
            { itemOptionsRows }
        </div>
    );
}

export default ItemOptions;