import React from "react";
import StatRow from "./StatRow";

function StatsSection(props) {
    return (
        <div id="statsSection">
            <table id="statsTable">
                <tr>
                    <th>Base</th>
                    <th>EV</th>
                    <th>IV</th>
                    <th>stat</th>
                </tr>
                <StatRow 
                    statName="exampleStatName"
                    baseStat="exampleBaseStat"
                    statState="??"
                    setStatState="??"
                />
                <StatRow 
                    statName="exampleStatName"
                    baseStat="exampleBaseStat"
                    statState="??"
                    setStatState="??"
                />
                <StatRow 
                    statName="exampleStatName"
                    baseStat="exampleBaseStat"
                    statState="??"
                    setStatState="??"
                />
                <StatRow 
                    statName="exampleStatName"
                    baseStat="exampleBaseStat"
                    statState="??"
                    setStatState="??"
                />
                <StatRow 
                    statName="exampleStatName"
                    baseStat="exampleBaseStat"
                    statState="??"
                    setStatState="??"
                />
                <StatRow 
                    statName="exampleStatName"
                    baseStat="exampleBaseStat"
                    statState="??"
                    setStatState="??"
                />
            </table>

            <div>
            <p>remaining EVs:</p>
            <p>{"(calc remaining evs)"}</p>
            </div>

            <label htmlFor="natureSelect">Nature</label>
            <select id="natureSelect" name="teraType">
                <option value="example-nature1">example-nature1</option>
                <option value="example-nature2">example-nature2</option>
            </select>

        </div>
    );
}

export default StatsSection;