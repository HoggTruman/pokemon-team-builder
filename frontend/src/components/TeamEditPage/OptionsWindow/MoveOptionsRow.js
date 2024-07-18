import React from "react";

function MoveOptionsRow(props) {

    return (
        <button className="row move">
            <div className="col name">{"movename"}</div>
            <div className="col type">
                <img
                    src=""
                    alt="type-image"
                />
            </div>
            <div className="col category">
                <img
                    src=""
                    alt="category-image"
                />
            </div>
            <div className="col stat">{"pow"}</div>
            <div className="col stat">{"acc"}</div>
            <div className="col stat">{"pp"}</div>
            <div className="col effect">{"effect"}</div>
        </button>
    )
}

export default MoveOptionsRow;