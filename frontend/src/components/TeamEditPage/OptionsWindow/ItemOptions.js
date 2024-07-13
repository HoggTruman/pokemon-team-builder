import React from "react";
import ItemOptionsRow from "./ItemOptionsRow";

function ItemOptions(props) {
    let itemOptionsRows = props.itemList.map(item => (
        <ItemOptionsRow
            key={"item.id"}
            item={item}
        />
    ))

    return (
        <table id="itemOptionsTable" className="optionsTable">
            <tr className="optionsHeaders">
                <th>{"(Icon)"}</th>
                <th>Name</th>
                <th>Effect</th>
            </tr>
            { itemOptionsRows }
        </table>
    );
}

export default ItemOptions;