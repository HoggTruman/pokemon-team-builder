import React from "react";

function ItemOptionsRow(props) {

    return (
        <tr>
            <td>
                <img
                    src=""
                    alt="icon"
                    className="optionsRowIcon"
                />
            </td>
            <td>
                {"name"}
            </td>
            <td>
                {"effect"}
            </td>
        </tr>
    )
}

export default ItemOptionsRow;