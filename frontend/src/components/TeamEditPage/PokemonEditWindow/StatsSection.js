import React from "react";
import StatRow from "./StatRow";

import "./StatsSection.css";

function StatsSection(props) {
    const MAX_EVS = 508;

    const activePokemonData = props.data.pokemon.find(x => x.identifier == props.activePokemon.pokemonName);
    const activeNatureData = props.data.natures.find(x => x.id === Number(props.activePokemon.natureId));

    let remainingEVs = (MAX_EVS 
        - props.activePokemon.hpEV 
        - props.activePokemon.attackEV 
        - props.activePokemon.defenseEV 
        - props.activePokemon.specialAttackEV 
        - props.activePokemon.specialDefenseEV 
        - props.activePokemon.speedEV
    );


    function handleNatureSelectChange(e) {
        props.setTeamEdit(team => {
            props.activePokemon.natureId = e.target.value;
            return {...team};
        })
    }


    return (
        <div id="statsSection">
            <table id="statsTable">
                <thead>
                    <tr>
                        <th>{/* stat name */}</th>
                        <th>Base</th>
                        <th>EV</th>
                        <th>IV</th>
                        <th>stat</th>
                    </tr>
                </thead>
                <tbody>
                    <StatRow 
                        activePokemon={props.activePokemon}
                        remainingEVs={remainingEVs}
                        statName="HP"
                        baseStat={activePokemonData?.baseStats.hp}
                        evKey={"hpEV"}
                        ivKey={"hpIV"}
                        natureMultiplier={1}
                        setTeamEdit={props.setTeamEdit}
                    />
                    <StatRow 
                        activePokemon={props.activePokemon}
                        remainingEVs={remainingEVs}
                        statName="Attack"
                        baseStat={activePokemonData?.baseStats.attack}
                        evKey={"attackEV"}
                        ivKey={"attackIV"}
                        natureMultiplier={activeNatureData.attackMultiplier}
                        setTeamEdit={props.setTeamEdit}
                    />
                    <StatRow
                        activePokemon={props.activePokemon}
                        remainingEVs={remainingEVs}
                        statName="Defense"
                        baseStat={activePokemonData?.baseStats.defense}
                        evKey={"defenseEV"}
                        ivKey={"defenseIV"}
                        natureMultiplier={activeNatureData.defenseMultiplier}
                        setTeamEdit={props.setTeamEdit}
                    />
                    <StatRow
                        activePokemon={props.activePokemon}
                        remainingEVs={remainingEVs}
                        statName="Sp. Atk."
                        baseStat={activePokemonData?.baseStats.specialAttack}
                        evKey={"specialAttackEV"}
                        ivKey={"specialAttackIV"}
                        natureMultiplier={activeNatureData.specialAttackMultiplier}
                        setTeamEdit={props.setTeamEdit}
                    />
                    <StatRow
                        activePokemon={props.activePokemon}
                        remainingEVs={remainingEVs}
                        statName="Sp. Def."
                        baseStat={activePokemonData?.baseStats.specialDefense}
                        evKey={"specialDefenseEV"}
                        ivKey={"specialDefenseIV"}
                        natureMultiplier={activeNatureData.specialDefenseMultiplier}
                        setTeamEdit={props.setTeamEdit}
                    />
                    <StatRow
                        activePokemon={props.activePokemon}
                        remainingEVs={remainingEVs}
                        statName="Speed"
                        baseStat={activePokemonData?.baseStats.speed}
                        evKey={"speedEV"}
                        ivKey={"speedIV"}
                        natureMultiplier={activeNatureData.speedMultiplier}
                        setTeamEdit={props.setTeamEdit}
                    />
                </tbody>
            </table>

            <div>
            <p
                id="remainingEVs"
                className={remainingEVs < 0? "warning":""}
            >
                Remaining EVs: <span>{remainingEVs}</span>
            </p>
            </div>

            <label htmlFor="natureSelect">Nature</label>
            <select 
                id="natureSelect" 
                name="teraType"
                value={props.activePokemon.natureId}
                onChange={e => handleNatureSelectChange(e)}
            >
                {
                    props.data.natures.map(nature => (
                        <option
                            key={nature.identifier}
                            value={nature.id}
                        >
                            {nature.identifier}    
                        </option>
                    ))
                }
            </select>

        </div>
    );
}

export default StatsSection;