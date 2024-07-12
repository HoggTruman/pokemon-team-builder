import React from "react";

function PokemonOptionsRow(props) {

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
                {"type images"}
            </td>
            <td>
                {"abilities"}
            </td>
            <td>
                {"hp"}
            </td>
            <td>
                {"atk"}
            </td>
            <td>
                {"def"}
            </td>
            <td>
                {"spatk"}
            </td>
            <td>
                {"spdef"}
            </td>
            <td>
                {"speed"}
            </td>
            <td>
                {"total"}
            </td>
        </tr>
    )
}

export default PokemonOptionsRow;