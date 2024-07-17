import React from "react";

function AbilityOptionsRow(props) {

    return (
        <button className="row ability">
            <div className="col name">
                {"name"}
            </div>
            <div className="col effect">
                {"effect"}
            </div>
        </button>
    )
}

export default AbilityOptionsRow;