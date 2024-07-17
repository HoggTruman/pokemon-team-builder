import React from "react";

function ItemOptionsRow(props) {

    return (
        <button className="row item">
            <div className="col icon">
                <img
                    src=""
                    alt="icon"
                    className="optionsRowIcon"
                />
            </div>
            <div className="col name">
                {"name"}
            </div>
            <div className="col effect">
                {"effect"}
            </div>
        </button>
    )
}

export default ItemOptionsRow;