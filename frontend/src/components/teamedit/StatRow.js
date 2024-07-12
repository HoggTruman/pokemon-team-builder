import React from "react";

function StatRow(props) {
    // MAYBE USE RANGE FOR EVs INSTEAD AND CONTROL MAX BASED ON REMAINING EVs
    return (
        <tr className="statRow">
            <td>
                <p>statname</p>
                <p>basestat value</p>
            </td>
            <td>
                <input type="number" min={0} max={252} step={4} defaultValue={0} name={"statnameEV"}/>
            </td>
            <td>
                <input type="number" min={0} max={31} defaultValue={31} name={"statnameIV"}/>
            </td>
            <td>
                <p>calculate stat here</p>
            </td>
        </tr>
    );
}

export default StatRow;