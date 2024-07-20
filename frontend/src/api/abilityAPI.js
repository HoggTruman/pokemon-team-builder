export function getAllAbilities() {
    const abilities = [
        {
          "id": 1,
          "identifier": "stench",
          "flavorText": "By releasing a stench when attacking, the Pokémon may cause the target to flinch."
        },
        {
          "id": 2,
          "identifier": "drizzle",
          "flavorText": "The Pokémon makes it rain when it enters a battle."
        },
        {
          "id": 3,
          "identifier": "speed-boost",
          "flavorText": "The Pokémon's Speed stat is boosted every turn."
        },
        {
          "id": 4,
          "identifier": "battle-armor",
          "flavorText": "Hard armor protects the Pokémon from critical hits."
        },
        {
          "id": 5,
          "identifier": "sturdy",
          "flavorText": "The Pokémon cannot be knocked out by a single hit as long as its HP is full. One-hit KO moves will also fail to knock it out."
        },
        {
          "id": 6,
          "identifier": "damp",
          "flavorText": "The Pokémon dampens its surroundings, preventing all Pokémon from using explosive moves such as Self-Destruct."
        },
        {
          "id": 7,
          "identifier": "limber",
          "flavorText": "The Pokémon's limber body prevents it from being paralyzed."
        },
        {
          "id": 8,
          "identifier": "sand-veil",
          "flavorText": "Boosts the Pokémon's evasiveness in a sandstorm."
        },
        {
          "id": 9,
          "identifier": "static",
          "flavorText": "The Pokémon is charged with static electricity and may paralyze attackers that make direct contact with it."
        },
        {
          "id": 10,
          "identifier": "volt-absorb",
          "flavorText": "If hit by an Electric-type move, the Pokémon has its HP restored instead of taking damage."
        },
        {
          "id": 11,
          "identifier": "water-absorb",
          "flavorText": "If hit by a Water-type move, the Pokémon has its HP restored instead of taking damage."
        },
        {
          "id": 12,
          "identifier": "oblivious",
          "flavorText": "The Pokémon is oblivious, keeping it from being infatuated, falling for taunts, or being affected by Intimidate."
        },
        {
          "id": 13,
          "identifier": "cloud-nine",
          "flavorText": "Eliminates the effects of weather."
        },
        {
          "id": 14,
          "identifier": "compound-eyes",
          "flavorText": "The Pokémon's compound eyes boost its accuracy."
        },
        {
          "id": 15,
          "identifier": "insomnia",
          "flavorText": "The Pokémon's insomnia prevents it from falling asleep."
        },
        {
          "id": 16,
          "identifier": "color-change",
          "flavorText": "The Pokémon’s type becomes the type of the move\nused on it."
        },
        {
          "id": 17,
          "identifier": "immunity",
          "flavorText": "The Pokémon's immune system prevents it from being poisoned."
        },
        {
          "id": 18,
          "identifier": "flash-fire",
          "flavorText": "If hit by a Fire-type move, the Pokémon absorbs the flames and uses them to power up its own Fire-type moves."
        },
        {
          "id": 19,
          "identifier": "shield-dust",
          "flavorText": "Protective dust shields the Pokémon from the additional effects of moves."
        },
        {
          "id": 20,
          "identifier": "own-tempo",
          "flavorText": "The Pokémon sticks to its own tempo, preventing it from becoming confused or being affected by Intimidate."
        },
        {
          "id": 21,
          "identifier": "suction-cups",
          "flavorText": "The Pokémon uses suction cups to stay in one spot. This protects it from moves and items that would force it to switch out."
        },
        {
          "id": 22,
          "identifier": "intimidate",
          "flavorText": "When the Pokémon enters a battle, it intimidates opposing Pokémon and makes them cower, lowering their Attack stats."
        },
        {
          "id": 23,
          "identifier": "shadow-tag",
          "flavorText": "The Pokémon steps on the opposing Pokémon's shadows to prevent them from fleeing or switching out."
        },
        {
          "id": 24,
          "identifier": "rough-skin",
          "flavorText": "The Pokémon's rough skin damages attackers that make direct contact with it."
        },
        {
          "id": 25,
          "identifier": "wonder-guard",
          "flavorText": "Its mysterious power only lets supereffective moves\nhit the Pokémon."
        },
        {
          "id": 26,
          "identifier": "levitate",
          "flavorText": "By floating in the air, the Pokémon receives full immunity to all Ground-type moves."
        },
        {
          "id": 27,
          "identifier": "effect-spore",
          "flavorText": "Contact with the Pokémon may inflict poison, sleep, or paralysis on the attacker."
        },
        {
          "id": 28,
          "identifier": "synchronize",
          "flavorText": "If the Pokémon is burned, paralyzed, or poisoned by another Pokémon, that Pokémon will be inflicted with the same status condition."
        },
        {
          "id": 29,
          "identifier": "clear-body",
          "flavorText": "Prevents other Pokémon's moves or Abilities from lowering the Pokémon's stats."
        },
        {
          "id": 30,
          "identifier": "natural-cure",
          "flavorText": "The Pokémon's status conditions are cured when it switches out."
        },
        {
          "id": 31,
          "identifier": "lightning-rod",
          "flavorText": "The Pokémon draws in all Electric-type moves. Instead of taking damage from them, its Sp. Atk stat is boosted."
        },
        {
          "id": 32,
          "identifier": "serene-grace",
          "flavorText": "Raises the likelihood of additional effects occurring when the Pokémon uses its moves."
        },
        {
          "id": 33,
          "identifier": "swift-swim",
          "flavorText": "Boosts the Pokémon's Speed stat in rain."
        },
        {
          "id": 34,
          "identifier": "chlorophyll",
          "flavorText": "Boosts the Pokémon's Speed stat in harsh sunlight."
        },
        {
          "id": 35,
          "identifier": "illuminate",
          "flavorText": "By illuminating its surroundings, the Pokémon prevents its accuracy from being lowered."
        },
        {
          "id": 36,
          "identifier": "trace",
          "flavorText": "When it enters a battle, the Pokémon copies an opposing Pokémon's Ability."
        },
        {
          "id": 37,
          "identifier": "huge-power",
          "flavorText": "Doubles the Pokémon's Attack stat."
        },
        {
          "id": 38,
          "identifier": "poison-point",
          "flavorText": "Contact with the Pokémon may poison the attacker."
        },
        {
          "id": 39,
          "identifier": "inner-focus",
          "flavorText": "The Pokémon's intense focus prevents it from flinching or being affected by Intimidate."
        },
        {
          "id": 40,
          "identifier": "magma-armor",
          "flavorText": "The Pokémon’s hot magma coating prevents it from being frozen."
        },
        {
          "id": 41,
          "identifier": "water-veil",
          "flavorText": "The Pokémon's water veil prevents it from being burned."
        },
        {
          "id": 42,
          "identifier": "magnet-pull",
          "flavorText": "Prevents Steel-type Pokémon from fleeing by pulling them in with magnetism."
        },
        {
          "id": 43,
          "identifier": "soundproof",
          "flavorText": "Soundproofing gives the Pokémon full immunity to all sound-based moves."
        },
        {
          "id": 44,
          "identifier": "rain-dish",
          "flavorText": "The Pokémon gradually regains HP in rain."
        },
        {
          "id": 45,
          "identifier": "sand-stream",
          "flavorText": "The Pokémon summons a sandstorm when it enters a battle."
        },
        {
          "id": 46,
          "identifier": "pressure",
          "flavorText": "Puts other Pokémon under pressure, causing them to expend more PP to use their moves."
        },
        {
          "id": 47,
          "identifier": "thick-fat",
          "flavorText": "The Pokémon is protected by a layer of thick fat, which halves the damage taken from Fire- and Ice-type moves."
        },
        {
          "id": 48,
          "identifier": "early-bird",
          "flavorText": "The Pokémon awakens from sleep twice as fast as other Pokémon."
        },
        {
          "id": 49,
          "identifier": "flame-body",
          "flavorText": "Contact with the Pokémon may burn the attacker."
        },
        {
          "id": 50,
          "identifier": "run-away",
          "flavorText": "Enables a sure getaway from wild Pokémon."
        },
        {
          "id": 51,
          "identifier": "keen-eye",
          "flavorText": "The Pokémon's keen eyes prevent its accuracy from being lowered."
        },
        {
          "id": 52,
          "identifier": "hyper-cutter",
          "flavorText": "The Pokémon's prized, mighty pincers prevent other Pokémon from lowering its Attack stat."
        },
        {
          "id": 53,
          "identifier": "pickup",
          "flavorText": "The Pokémon may pick up an item another Pokémon used during a battle. It may pick up items outside of battle, too."
        },
        {
          "id": 54,
          "identifier": "truant",
          "flavorText": "Each time the Pokémon uses a move, it spends the next turn loafing around."
        },
        {
          "id": 55,
          "identifier": "hustle",
          "flavorText": "Boosts the Pokémon's Attack stat but lowers its accuracy."
        },
        {
          "id": 56,
          "identifier": "cute-charm",
          "flavorText": "The Pokémon may infatuate attackers that make direct contact with it."
        },
        {
          "id": 57,
          "identifier": "plus",
          "flavorText": "Boosts the Sp. Atk stat of the Pokémon if an ally with the Plus or Minus Ability is also in battle."
        },
        {
          "id": 58,
          "identifier": "minus",
          "flavorText": "Boosts the Sp. Atk stat of the Pokémon if an ally with the Plus or Minus Ability is also in battle."
        },
        {
          "id": 59,
          "identifier": "forecast",
          "flavorText": "The Pokémon transforms with the weather to change\nits type to Water, Fire, or Ice."
        },
        {
          "id": 60,
          "identifier": "sticky-hold",
          "flavorText": "The Pokémon's held items cling to its sticky body and cannot be removed by other Pokémon."
        },
        {
          "id": 61,
          "identifier": "shed-skin",
          "flavorText": "The Pokémon may cure its own status conditions by shedding its skin."
        },
        {
          "id": 62,
          "identifier": "guts",
          "flavorText": "It's so gutsy that having a status condition boosts the Pokémon's Attack stat."
        },
        {
          "id": 63,
          "identifier": "marvel-scale",
          "flavorText": "The Pokémon's marvelous scales boost its Defense stat if it has a status condition."
        },
        {
          "id": 64,
          "identifier": "liquid-ooze",
          "flavorText": "The strong stench of the Pokémon's oozed liquid damages attackers that use HP-draining moves."
        },
        {
          "id": 65,
          "identifier": "overgrow",
          "flavorText": "Powers up Grass-type moves when the Pokémon's HP is low."
        },
        {
          "id": 66,
          "identifier": "blaze",
          "flavorText": "Powers up Fire-type moves when the Pokémon's HP is low."
        },
        {
          "id": 67,
          "identifier": "torrent",
          "flavorText": "Powers up Water-type moves when the Pokémon's HP is low."
        },
        {
          "id": 68,
          "identifier": "swarm",
          "flavorText": "Powers up Bug-type moves when the Pokémon's HP is low."
        },
        {
          "id": 69,
          "identifier": "rock-head",
          "flavorText": "Protects the Pokémon from recoil damage."
        },
        {
          "id": 70,
          "identifier": "drought",
          "flavorText": "Turns the sunlight harsh when the Pokémon enters a battle."
        },
        {
          "id": 71,
          "identifier": "arena-trap",
          "flavorText": "Prevents opposing Pokémon from fleeing from battle."
        },
        {
          "id": 72,
          "identifier": "vital-spirit",
          "flavorText": "The Pokémon is full of vitality, and that prevents it from falling asleep."
        },
        {
          "id": 73,
          "identifier": "white-smoke",
          "flavorText": "The Pokémon is protected by its white smoke, which prevents other Pokémon from lowering its stats."
        },
        {
          "id": 74,
          "identifier": "pure-power",
          "flavorText": "Using its pure power, the Pokémon doubles its Attack stat."
        },
        {
          "id": 75,
          "identifier": "shell-armor",
          "flavorText": "A hard shell protects the Pokémon from critical hits."
        },
        {
          "id": 76,
          "identifier": "air-lock",
          "flavorText": "Eliminates the effects of weather."
        },
        {
          "id": 77,
          "identifier": "tangled-feet",
          "flavorText": "Boosts the Pokémon's evasiveness if it is confused."
        },
        {
          "id": 78,
          "identifier": "motor-drive",
          "flavorText": "The Pokémon takes no damage when hit by Electric-type moves. Instead, its Speed stat is boosted."
        },
        {
          "id": 79,
          "identifier": "rivalry",
          "flavorText": "The Pokémon's competitive spirit makes it deal more damage to Pokémon of the same gender, but less damage to Pokémon of the opposite gender."
        },
        {
          "id": 80,
          "identifier": "steadfast",
          "flavorText": "The Pokémon's determination boosts its Speed stat every time it flinches."
        },
        {
          "id": 81,
          "identifier": "snow-cloak",
          "flavorText": "Boosts the Pokémon's evasiveness in snow."
        },
        {
          "id": 82,
          "identifier": "gluttony",
          "flavorText": "If the Pokémon is holding a Berry to be eaten when its HP is low, it will instead eat the Berry when its HP drops to half or less."
        },
        {
          "id": 83,
          "identifier": "anger-point",
          "flavorText": "The Pokémon is angered when it takes a critical hit, and that maxes its Attack stat."
        },
        {
          "id": 84,
          "identifier": "unburden",
          "flavorText": "Boosts the Speed stat if the Pokémon's held item is used or lost."
        },
        {
          "id": 85,
          "identifier": "heatproof",
          "flavorText": "The Pokémon's heatproof body halves the damage taken from Fire-type moves."
        },
        {
          "id": 86,
          "identifier": "simple",
          "flavorText": "Doubles the effects of the Pokémon's stat changes."
        },
        {
          "id": 87,
          "identifier": "dry-skin",
          "flavorText": "Restores the Pokémon's HP in rain or when it is hit by Water-type moves. Reduces HP in harsh sunlight, and increases the damage received from Fire-type moves."
        },
        {
          "id": 88,
          "identifier": "download",
          "flavorText": "The Pokémon compares an opposing Pokémon's Defense and Sp. Def stats before raising its own Attack or Sp. Atk stat—whichever will be more effective."
        },
        {
          "id": 89,
          "identifier": "iron-fist",
          "flavorText": "Powers up punching moves."
        },
        {
          "id": 90,
          "identifier": "poison-heal",
          "flavorText": "If poisoned, the Pokémon has its HP restored instead of taking damage."
        },
        {
          "id": 91,
          "identifier": "adaptability",
          "flavorText": "Powers up moves of the same type as the Pokémon."
        },
        {
          "id": 92,
          "identifier": "skill-link",
          "flavorText": "Maximizes the number of times multistrike moves hit."
        },
        {
          "id": 93,
          "identifier": "hydration",
          "flavorText": "Cures the Pokémon's status conditions in rain."
        },
        {
          "id": 94,
          "identifier": "solar-power",
          "flavorText": "In harsh sunlight, the Pokémon's Sp. Atk stat is boosted, but its HP decreases every turn."
        },
        {
          "id": 95,
          "identifier": "quick-feet",
          "flavorText": "Boosts the Speed stat if the Pokémon has a status condition."
        },
        {
          "id": 96,
          "identifier": "normalize",
          "flavorText": "All the Pokémon’s moves become Normal type.\nThe power of those moves is boosted a little."
        },
        {
          "id": 97,
          "identifier": "sniper",
          "flavorText": "If the Pokémon's attack lands a critical hit, the attack is powered up even further."
        },
        {
          "id": 98,
          "identifier": "magic-guard",
          "flavorText": "The Pokémon only takes damage from attacks."
        },
        {
          "id": 99,
          "identifier": "no-guard",
          "flavorText": "The Pokémon employs no-guard tactics to ensure incoming and outgoing attacks always land. "
        },
        {
          "id": 100,
          "identifier": "stall",
          "flavorText": "The Pokémon is always the last to use its moves. "
        },
        {
          "id": 101,
          "identifier": "technician",
          "flavorText": "Powers up weak moves so the Pokémon can deal more damage with them."
        },
        {
          "id": 102,
          "identifier": "leaf-guard",
          "flavorText": "Prevents status conditions in harsh sunlight."
        },
        {
          "id": 103,
          "identifier": "klutz",
          "flavorText": "The Pokémon can't use any held items."
        },
        {
          "id": 104,
          "identifier": "mold-breaker",
          "flavorText": "The Pokémon's moves are unimpeded by the Ability of the target."
        },
        {
          "id": 105,
          "identifier": "super-luck",
          "flavorText": "The Pokémon is so lucky that the critical-hit ratios of its moves are boosted."
        },
        {
          "id": 106,
          "identifier": "aftermath",
          "flavorText": "Damages the attacker if it knocks out the Pokémon with a move that makes direct contact."
        },
        {
          "id": 107,
          "identifier": "anticipation",
          "flavorText": "The Pokémon can sense an opposing Pokémon's dangerous moves."
        },
        {
          "id": 108,
          "identifier": "forewarn",
          "flavorText": "When it enters a battle, the Pokémon can tell one of the moves an opposing Pokémon has."
        },
        {
          "id": 109,
          "identifier": "unaware",
          "flavorText": "When attacking, the Pokémon ignores the target's stat changes."
        },
        {
          "id": 110,
          "identifier": "tinted-lens",
          "flavorText": "The Pokémon can use “not very effective” moves to deal regular damage."
        },
        {
          "id": 111,
          "identifier": "filter",
          "flavorText": "Reduces the power of supereffective attacks that hit the Pokémon."
        },
        {
          "id": 112,
          "identifier": "slow-start",
          "flavorText": "For five turns, the Pokémon's Attack and Speed stats are halved."
        },
        {
          "id": 113,
          "identifier": "scrappy",
          "flavorText": "The Pokémon can hit Ghost-type Pokémon with Normal- and Fighting-type moves. It is also unaffected by Intimidate."
        },
        {
          "id": 114,
          "identifier": "storm-drain",
          "flavorText": "The Pokémon draws in all Water-type moves. Instead of taking damage from them, its Sp. Atk stat is boosted."
        },
        {
          "id": 115,
          "identifier": "ice-body",
          "flavorText": "The Pokémon gradually regains HP in snow."
        },
        {
          "id": 116,
          "identifier": "solid-rock",
          "flavorText": "Reduces the power of supereffective attacks that hit the Pokémon."
        },
        {
          "id": 117,
          "identifier": "snow-warning",
          "flavorText": "The Pokémon makes it snow when it enters a battle."
        },
        {
          "id": 118,
          "identifier": "honey-gather",
          "flavorText": "The Pokémon may gather Honey after a battle."
        },
        {
          "id": 119,
          "identifier": "frisk",
          "flavorText": "When it enters a battle, the Pokémon can check an opposing Pokémon's held item."
        },
        {
          "id": 120,
          "identifier": "reckless",
          "flavorText": "Powers up moves that have recoil damage."
        },
        {
          "id": 121,
          "identifier": "multitype",
          "flavorText": "Changes the Pokémon's type to match the plate it holds. "
        },
        {
          "id": 122,
          "identifier": "flower-gift",
          "flavorText": "Boosts the Attack and Sp. Def stats of itself\nand allies in harsh sunlight."
        },
        {
          "id": 123,
          "identifier": "bad-dreams",
          "flavorText": "Damages opposing Pokémon that are asleep."
        },
        {
          "id": 124,
          "identifier": "pickpocket",
          "flavorText": "The Pokémon steals the held item from attackers that made direct contact with it."
        },
        {
          "id": 125,
          "identifier": "sheer-force",
          "flavorText": "Removes any additional effects from the Pokémon's moves, but increases the moves' power."
        },
        {
          "id": 126,
          "identifier": "contrary",
          "flavorText": "Reverses any stat changes affecting the Pokémon so that attempts to boost its stats instead lower them—and attempts to lower its stats will boost them."
        },
        {
          "id": 127,
          "identifier": "unnerve",
          "flavorText": "Unnerves opposing Pokémon and makes them unable to eat Berries."
        },
        {
          "id": 128,
          "identifier": "defiant",
          "flavorText": "If the Pokémon has any stat lowered by an opposing Pokémon, its Attack stat will be boosted sharply."
        },
        {
          "id": 129,
          "identifier": "defeatist",
          "flavorText": "Halves the Pokémon’s Attack and Sp. Atk stats\nwhen its HP becomes half or less."
        },
        {
          "id": 130,
          "identifier": "cursed-body",
          "flavorText": "May disable a move that has dealt damage to the Pokémon."
        },
        {
          "id": 131,
          "identifier": "healer",
          "flavorText": "Sometimes cures the status conditions of the Pokémon's allies."
        },
        {
          "id": 132,
          "identifier": "friend-guard",
          "flavorText": "Reduces damage dealt to allies."
        },
        {
          "id": 133,
          "identifier": "weak-armor",
          "flavorText": "The Pokémon's Defense stat is lowered when it takes damage from physical moves, but its Speed stat is sharply boosted."
        },
        {
          "id": 134,
          "identifier": "heavy-metal",
          "flavorText": "Doubles the Pokémon's weight."
        },
        {
          "id": 135,
          "identifier": "light-metal",
          "flavorText": "Halves the Pokémon's weight."
        },
        {
          "id": 136,
          "identifier": "multiscale",
          "flavorText": "Reduces the amount of damage the Pokémon takes while its HP is full."
        },
        {
          "id": 137,
          "identifier": "toxic-boost",
          "flavorText": "Powers up physical moves when the Pokémon is poisoned."
        },
        {
          "id": 138,
          "identifier": "flare-boost",
          "flavorText": "Powers up special moves when the Pokémon is burned."
        },
        {
          "id": 139,
          "identifier": "harvest",
          "flavorText": "May create another Berry after one is used."
        },
        {
          "id": 140,
          "identifier": "telepathy",
          "flavorText": "The Pokémon anticipates and dodges the attacks of its allies."
        },
        {
          "id": 141,
          "identifier": "moody",
          "flavorText": "Every turn, one of the Pokémon's stats will be boosted sharply but another stat will be lowered."
        },
        {
          "id": 142,
          "identifier": "overcoat",
          "flavorText": "The Pokémon takes no damage from sandstorms. It is also protected from the effects of powders and spores."
        },
        {
          "id": 143,
          "identifier": "poison-touch",
          "flavorText": "May poison a target when the Pokémon makes contact."
        },
        {
          "id": 144,
          "identifier": "regenerator",
          "flavorText": "The Pokémon has a little of its HP restored when withdrawn from battle."
        },
        {
          "id": 145,
          "identifier": "big-pecks",
          "flavorText": "Prevents the Pokémon from having its Defense stat lowered."
        },
        {
          "id": 146,
          "identifier": "sand-rush",
          "flavorText": "Boosts the Pokémon's Speed stat in a sandstorm."
        },
        {
          "id": 147,
          "identifier": "wonder-skin",
          "flavorText": "Makes status moves more likely to miss the Pokémon."
        },
        {
          "id": 148,
          "identifier": "analytic",
          "flavorText": "Boosts the power of the Pokémon's move if it is the last to act that turn."
        },
        {
          "id": 149,
          "identifier": "illusion",
          "flavorText": "The Pokémon fools opponents by entering battle disguised as the last Pokémon in its Trainer's party."
        },
        {
          "id": 150,
          "identifier": "imposter",
          "flavorText": "The Pokémon transforms itself into the Pokémon it's facing."
        },
        {
          "id": 151,
          "identifier": "infiltrator",
          "flavorText": "The Pokémon's moves are unaffected by the target's barriers, substitutes, and the like."
        },
        {
          "id": 152,
          "identifier": "mummy",
          "flavorText": "Contact with the Pokémon changes the attacker’s\nAbility to Mummy."
        },
        {
          "id": 153,
          "identifier": "moxie",
          "flavorText": "When the Pokémon knocks out a target, it shows moxie, which boosts its Attack stat."
        },
        {
          "id": 154,
          "identifier": "justified",
          "flavorText": "When the Pokémon is hit by a Dark-type attack, its Attack stat is boosted by its sense of justice."
        },
        {
          "id": 155,
          "identifier": "rattled",
          "flavorText": "The Pokémon gets scared when hit by a Dark-, Ghost-, or Bug-type attack or if intimidated, which boosts its Speed stat."
        },
        {
          "id": 156,
          "identifier": "magic-bounce",
          "flavorText": "The Pokémon reflects status moves instead of getting hit by them."
        },
        {
          "id": 157,
          "identifier": "sap-sipper",
          "flavorText": "The Pokémon takes no damage when hit by Grass-type moves. Instead, its Attack stat is boosted."
        },
        {
          "id": 158,
          "identifier": "prankster",
          "flavorText": "Gives priority to the Pokémon's status moves."
        },
        {
          "id": 159,
          "identifier": "sand-force",
          "flavorText": "Boosts the power of Rock-, Ground-, and Steel-type moves in a sandstorm. "
        },
        {
          "id": 160,
          "identifier": "iron-barbs",
          "flavorText": "Inflicts damage on the attacker upon contact with\niron barbs."
        },
        {
          "id": 161,
          "identifier": "zen-mode",
          "flavorText": "Changes the Pokémon’s shape when HP is half\nor less."
        },
        {
          "id": 162,
          "identifier": "victory-star",
          "flavorText": "Boosts the accuracy of its allies and itself."
        },
        {
          "id": 163,
          "identifier": "turboblaze",
          "flavorText": "The Pokémon's moves are unimpeded by the Ability of the target."
        },
        {
          "id": 164,
          "identifier": "teravolt",
          "flavorText": "The Pokémon's moves are unimpeded by the Ability of the target."
        },
        {
          "id": 165,
          "identifier": "aroma-veil",
          "flavorText": "Protects the Pokémon and its allies from effects that prevent the use of moves."
        },
        {
          "id": 166,
          "identifier": "flower-veil",
          "flavorText": "Ally Grass-type Pokémon are protected from status conditions and the lowering of their stats."
        },
        {
          "id": 167,
          "identifier": "cheek-pouch",
          "flavorText": "The Pokémon's HP is restored when it eats any Berry, in addition to the Berry's usual effect."
        },
        {
          "id": 168,
          "identifier": "protean",
          "flavorText": "Changes the Pokémon's type to the type of the move it's about to use. This works only once each time the Pokémon enters battle."
        },
        {
          "id": 169,
          "identifier": "fur-coat",
          "flavorText": "Halves the damage from physical moves."
        },
        {
          "id": 170,
          "identifier": "magician",
          "flavorText": "The Pokémon steals the held item from any target it hits with a move."
        },
        {
          "id": 171,
          "identifier": "bulletproof",
          "flavorText": "Protects the Pokémon from ball and bomb moves."
        },
        {
          "id": 172,
          "identifier": "competitive",
          "flavorText": "Boosts the Pokémon's Sp. Atk stat sharply when its stats are lowered by an opposing Pokémon."
        },
        {
          "id": 173,
          "identifier": "strong-jaw",
          "flavorText": "The Pokémon's strong jaw boosts the power of its biting moves."
        },
        {
          "id": 174,
          "identifier": "refrigerate",
          "flavorText": "Normal-type moves become Ice-type moves.\nThe power of those moves is boosted a little."
        },
        {
          "id": 175,
          "identifier": "sweet-veil",
          "flavorText": "Prevents the Pokémon and its allies from falling asleep."
        },
        {
          "id": 176,
          "identifier": "stance-change",
          "flavorText": "The Pokémon changes its form to Blade Forme when\nit uses an attack move and changes to Shield Forme\nwhen it uses King’s Shield."
        },
        {
          "id": 177,
          "identifier": "gale-wings",
          "flavorText": "Gives priority to the Pokémon's Flying-type moves while its HP is full."
        },
        {
          "id": 178,
          "identifier": "mega-launcher",
          "flavorText": "Powers up pulse moves."
        },
        {
          "id": 179,
          "identifier": "grass-pelt",
          "flavorText": "Boosts the Pokémon's Defense stat on Grassy Terrain."
        },
        {
          "id": 180,
          "identifier": "symbiosis",
          "flavorText": "The Pokémon passes its held item to an ally that has used up an item."
        },
        {
          "id": 181,
          "identifier": "tough-claws",
          "flavorText": "Powers up moves that make direct contact."
        },
        {
          "id": 182,
          "identifier": "pixilate",
          "flavorText": "Normal-type moves become Fairy-type moves. The power of those moves is boosted a little."
        },
        {
          "id": 183,
          "identifier": "gooey",
          "flavorText": "Contact with the Pokémon lowers the attacker's Speed stat."
        },
        {
          "id": 184,
          "identifier": "aerilate",
          "flavorText": "Normal-type moves become Flying-type moves.\nThe power of those moves is boosted a little."
        },
        {
          "id": 185,
          "identifier": "parental-bond",
          "flavorText": "Parent and child each attacks."
        },
        {
          "id": 186,
          "identifier": "dark-aura",
          "flavorText": "Powers up each Pokémon’s Dark-type moves."
        },
        {
          "id": 187,
          "identifier": "fairy-aura",
          "flavorText": "Powers up each Pokémon’s Fairy-type moves."
        },
        {
          "id": 188,
          "identifier": "aura-break",
          "flavorText": "The effects of “Aura” Abilities are reversed\nto lower the power of affected moves."
        },
        {
          "id": 189,
          "identifier": "primordial-sea",
          "flavorText": "The Pokémon changes the weather to nullify\nFire-type attacks."
        },
        {
          "id": 190,
          "identifier": "desolate-land",
          "flavorText": "The Pokémon changes the weather to nullify\nWater-type attacks."
        },
        {
          "id": 191,
          "identifier": "delta-stream",
          "flavorText": "The Pokémon changes the weather to eliminate all\nof the Flying type’s weaknesses."
        },
        {
          "id": 192,
          "identifier": "stamina",
          "flavorText": "Boosts the Defense stat when the Pokémon is hit by an attack."
        },
        {
          "id": 193,
          "identifier": "wimp-out",
          "flavorText": "The Pokémon cowardly switches out when its HP\nbecomes half or less."
        },
        {
          "id": 194,
          "identifier": "emergency-exit",
          "flavorText": "The Pokémon, sensing danger, switches out when its\nHP becomes half or less."
        },
        {
          "id": 195,
          "identifier": "water-compaction",
          "flavorText": "Boosts the Defense stat sharply when the Pokémon is hit by a Water-type move."
        },
        {
          "id": 196,
          "identifier": "merciless",
          "flavorText": "The Pokémon's attacks become critical hits if the target is poisoned."
        },
        {
          "id": 197,
          "identifier": "shields-down",
          "flavorText": "When its HP drops to half or less, the Pokémon's shell breaks and it becomes aggressive."
        },
        {
          "id": 198,
          "identifier": "stakeout",
          "flavorText": "Doubles the damage dealt to a target that has just switched into battle."
        },
        {
          "id": 199,
          "identifier": "water-bubble",
          "flavorText": "Lowers the power of Fire-type moves that hit the Pokémon and prevents it from being burned."
        },
        {
          "id": 200,
          "identifier": "steelworker",
          "flavorText": "Powers up Steel-type moves."
        },
        {
          "id": 201,
          "identifier": "berserk",
          "flavorText": "Boosts the Pokémon's Sp. Atk stat when it takes a hit that causes its HP to drop to half or less."
        },
        {
          "id": 202,
          "identifier": "slush-rush",
          "flavorText": "Boosts the Pokémon's Speed stat in snow."
        },
        {
          "id": 203,
          "identifier": "long-reach",
          "flavorText": "The Pokémon uses its moves without making contact with the target."
        },
        {
          "id": 204,
          "identifier": "liquid-voice",
          "flavorText": "Sound-based moves become Water-type moves."
        },
        {
          "id": 205,
          "identifier": "triage",
          "flavorText": "Gives priority to the Pokémon's healing moves."
        },
        {
          "id": 206,
          "identifier": "galvanize",
          "flavorText": "Normal-type moves become Electric-type moves. The power of those moves is boosted a little."
        },
        {
          "id": 207,
          "identifier": "surge-surfer",
          "flavorText": "Doubles the Pokémon's Speed stat on Electric Terrain."
        },
        {
          "id": 208,
          "identifier": "schooling",
          "flavorText": "When it has a lot of HP, the Pokémon forms a\npowerful school. It stops schooling when its HP\nis low."
        },
        {
          "id": 209,
          "identifier": "disguise",
          "flavorText": "Once per battle, the shroud that covers the Pokémon can protect it from an attack."
        },
        {
          "id": 210,
          "identifier": "battle-bond",
          "flavorText": "When the Pokémon knocks out a target, its bond with its Trainer is strengthened, and its Attack, Sp. Atk, and Speed stats are boosted."
        },
        {
          "id": 211,
          "identifier": "power-construct",
          "flavorText": "Other Cells gather to aid when its HP becomes\nhalf or less. Then the Pokémon changes\nits form to Complete Forme."
        },
        {
          "id": 212,
          "identifier": "corrosion",
          "flavorText": "The Pokémon can poison the target even if it's a Steel or Poison type."
        },
        {
          "id": 213,
          "identifier": "comatose",
          "flavorText": "The Pokémon is always drowsing and will never wake up. It can attack while in its sleeping state."
        },
        {
          "id": 214,
          "identifier": "queenly-majesty",
          "flavorText": "When the Pokémon uses Surf or Dive, it will come back with prey. When it takes damage, it will spit out the prey to attack."
        },
        {
          "id": 215,
          "identifier": "innards-out",
          "flavorText": "Damages the attacker landing the finishing hit\nby the amount equal to its last HP."
        },
        {
          "id": 216,
          "identifier": "dancer",
          "flavorText": "Whenever a dance move is used in battle, the Pokémon will copy the user to immediately perform that dance move itself."
        },
        {
          "id": 217,
          "identifier": "battery",
          "flavorText": "Powers up ally Pokémon's special moves."
        },
        {
          "id": 218,
          "identifier": "fluffy",
          "flavorText": "Halves the damage taken from moves that make direct contact, but doubles that of Fire-type moves."
        },
        {
          "id": 219,
          "identifier": "dazzling",
          "flavorText": "The Pokémon dazzles its opponents, making them unable to use priority moves against the Pokémon or its allies."
        },
        {
          "id": 220,
          "identifier": "soul-heart",
          "flavorText": "Boosts the Pokémon's Sp. Atk stat every time another Pokémon faints."
        },
        {
          "id": 221,
          "identifier": "tangling-hair",
          "flavorText": "Contact with the Pokémon lowers the attacker's Speed stat."
        },
        {
          "id": 222,
          "identifier": "receiver",
          "flavorText": "The Pokémon copies the Ability of a defeated ally."
        },
        {
          "id": 223,
          "identifier": "power-of-alchemy",
          "flavorText": "The Pokémon copies the Ability of a defeated ally."
        },
        {
          "id": 224,
          "identifier": "beast-boost",
          "flavorText": "The Pokémon boosts its most proficient stat each\ntime it knocks out a Pokémon."
        },
        {
          "id": 225,
          "identifier": "rks-system",
          "flavorText": "Changes the Pokémon’s type to match the\nmemory disc it holds."
        },
        {
          "id": 226,
          "identifier": "electric-surge",
          "flavorText": "Turns the ground into Electric Terrain when the Pokémon enters a battle."
        },
        {
          "id": 227,
          "identifier": "psychic-surge",
          "flavorText": "Turns the ground into Psychic Terrain when the Pokémon enters a battle."
        },
        {
          "id": 228,
          "identifier": "misty-surge",
          "flavorText": "Turns the ground into Misty Terrain when the Pokémon enters a battle."
        },
        {
          "id": 229,
          "identifier": "grassy-surge",
          "flavorText": "Turns the ground into Grassy Terrain when the Pokémon enters a battle."
        },
        {
          "id": 230,
          "identifier": "full-metal-body",
          "flavorText": "Prevents other Pokémon’s moves or Abilities from\nlowering the Pokémon’s stats."
        },
        {
          "id": 231,
          "identifier": "shadow-shield",
          "flavorText": "Reduces the amount of damage the Pokémon takes\nwhile its HP is full."
        },
        {
          "id": 232,
          "identifier": "prism-armor",
          "flavorText": "Reduces the power of supereffective attacks taken."
        },
        {
          "id": 233,
          "identifier": "neuroforce",
          "flavorText": "Powers up moves that are super effective."
        },
        {
          "id": 234,
          "identifier": "intrepid-sword",
          "flavorText": "Boosts the Pokémon’s Attack stat the first time the Pokémon enters a battle."
        },
        {
          "id": 235,
          "identifier": "dauntless-shield",
          "flavorText": "Boosts the Pokémon’s Defense stat the first time the Pokémon enters a battle."
        },
        {
          "id": 236,
          "identifier": "libero",
          "flavorText": "Changes the Pokémon's type to the type of the move it's about to use. This works only once each time the Pokémon enters battle."
        },
        {
          "id": 237,
          "identifier": "ball-fetch",
          "flavorText": "If the Pokémon is not holding an item, it will fetch\nthe Poké Ball from the first failed throw\nof the battle."
        },
        {
          "id": 238,
          "identifier": "cotton-down",
          "flavorText": "When the Pokémon is hit by an attack, it scatters\ncotton fluff around and lowers the Speed stat of\nall Pokémon except itself."
        },
        {
          "id": 239,
          "identifier": "propeller-tail",
          "flavorText": "Ignores the effects of opposing Pokémon's Abilities and moves that draw in moves."
        },
        {
          "id": 240,
          "identifier": "mirror-armor",
          "flavorText": "Bounces back only the stat-lowering effects that the Pokémon receives."
        },
        {
          "id": 241,
          "identifier": "gulp-missile",
          "flavorText": "When the Pokémon uses Surf or Dive, it will come back\nwith prey. When it takes damage, it will spit out the prey\nto attack."
        },
        {
          "id": 242,
          "identifier": "stalwart",
          "flavorText": "Ignores the effects of opposing Pokémon's Abilities and moves that draw in moves."
        },
        {
          "id": 243,
          "identifier": "steam-engine",
          "flavorText": "Boosts the Speed stat drastically when the Pokémon is hit by a Fire- or Water-type move."
        },
        {
          "id": 244,
          "identifier": "punk-rock",
          "flavorText": "Boosts the power of sound-based moves. The Pokémon also takes half the damage from these kinds of moves."
        },
        {
          "id": 245,
          "identifier": "sand-spit",
          "flavorText": "The Pokémon creates a sandstorm when it's hit by an attack."
        },
        {
          "id": 246,
          "identifier": "ice-scales",
          "flavorText": "The Pokémon is protected by ice scales, which halve the damage taken from special moves."
        },
        {
          "id": 247,
          "identifier": "ripen",
          "flavorText": "Ripens Berries and doubles their effect."
        },
        {
          "id": 248,
          "identifier": "ice-face",
          "flavorText": "The Pokémon's ice head can take a physical attack as a substitute, but the attack also changes the Pokémon's appearance. The ice will be restored when it snows."
        },
        {
          "id": 249,
          "identifier": "power-spot",
          "flavorText": "Just being next to the Pokémon powers up moves."
        },
        {
          "id": 250,
          "identifier": "mimicry",
          "flavorText": "Changes the Pokémon’s type depending on the terrain."
        },
        {
          "id": 251,
          "identifier": "screen-cleaner",
          "flavorText": "When the Pokémon enters a battle, the effects of\nLight Screen, Reflect, and Aurora Veil are nullified for\nboth opposing and ally Pokémon."
        },
        {
          "id": 252,
          "identifier": "steely-spirit",
          "flavorText": "Powers up the Steel-type moves of the Pokémon and its allies."
        },
        {
          "id": 253,
          "identifier": "perish-body",
          "flavorText": "When hit by a move that makes direct contact,\nthe Pokémon and the attacker will faint after three turns\nunless they switch out of battle."
        },
        {
          "id": 254,
          "identifier": "wandering-spirit",
          "flavorText": "The Pokémon exchanges Abilities with a Pokémon\nthat hits it with a move that makes direct contact."
        },
        {
          "id": 255,
          "identifier": "gorilla-tactics",
          "flavorText": "Boosts the Pokémon’s Attack stat but only allows\nthe use of the first selected move."
        },
        {
          "id": 256,
          "identifier": "neutralizing-gas",
          "flavorText": "While the Pokémon is in the battle, the effects of all other Pokémon's Abilities will be nullified or will not be triggered."
        },
        {
          "id": 257,
          "identifier": "pastel-veil",
          "flavorText": "Protects the Pokémon and its ally Pokémon from\nbeing poisoned."
        },
        {
          "id": 258,
          "identifier": "hunger-switch",
          "flavorText": "The Pokémon changes its form, alternating between its Full Belly Mode and Hangry Mode after the end of every turn."
        },
        {
          "id": 259,
          "identifier": "quick-draw",
          "flavorText": "Enables the Pokémon to move first occasionally."
        },
        {
          "id": 260,
          "identifier": "unseen-fist",
          "flavorText": "If the Pokémon uses moves that make direct contact, it can attack the target even if the target protects itself."
        },
        {
          "id": 261,
          "identifier": "curious-medicine",
          "flavorText": "When the Pokémon enters a battle, it scatters medicine from its shell, which removes all stat changes from allies."
        },
        {
          "id": 262,
          "identifier": "transistor",
          "flavorText": "Powers up Electric-type moves."
        },
        {
          "id": 263,
          "identifier": "dragons-maw",
          "flavorText": "Powers up Dragon-type moves."
        },
        {
          "id": 264,
          "identifier": "chilling-neigh",
          "flavorText": "When the Pokémon knocks out a target, it utters a chilling neigh, which boosts its Attack stat."
        },
        {
          "id": 265,
          "identifier": "grim-neigh",
          "flavorText": "When the Pokémon knocks out a target, it utters a terrifying neigh, which boosts its Sp. Atk stat."
        },
        {
          "id": 266,
          "identifier": "as-one-glastrier",
          "flavorText": "This Ability combines the effects of both Calyrex's Unnerve Ability and Glastrier's Chilling Neigh Ability."
        },
        {
          "id": 267,
          "identifier": "as-one-spectrier",
          "flavorText": "This Ability combines the effects of both Calyrex's Unnerve Ability and Spectrier's Grim Neigh Ability."
        },
        {
          "id": 268,
          "identifier": "lingering-aroma",
          "flavorText": "Contact with the Pokémon changes the attacker's Ability to Lingering Aroma."
        },
        {
          "id": 269,
          "identifier": "seed-sower",
          "flavorText": "Turns the ground into Grassy Terrain when the Pokémon is hit by an attack."
        },
        {
          "id": 270,
          "identifier": "thermal-exchange",
          "flavorText": "Boosts the Attack stat when the Pokémon is hit by a Fire-type move. The Pokémon also cannot be burned."
        },
        {
          "id": 271,
          "identifier": "anger-shell",
          "flavorText": "When an attack causes its HP to drop to half or less, the Pokémon gets angry. This lowers its Defense and Sp. Def stats but boosts its Attack, Sp. Atk, and Speed stats."
        },
        {
          "id": 272,
          "identifier": "purifying-salt",
          "flavorText": "The Pokémon's pure salt protects it from status conditions and halves the damage taken from Ghost-type moves."
        },
        {
          "id": 273,
          "identifier": "well-baked-body",
          "flavorText": "The Pokémon takes no damage when hit by Fire-type moves. Instead, its Defense stat is sharply boosted."
        },
        {
          "id": 274,
          "identifier": "wind-rider",
          "flavorText": "Boosts the Pokémon's Attack stat if Tailwind takes effect or if the Pokémon is hit by a wind move. The Pokémon also takes no damage from wind moves."
        },
        {
          "id": 275,
          "identifier": "guard-dog",
          "flavorText": "Boosts the Pokémon’s Attack stat if intimidated. Moves and items that would force the Pokémon to switch out also fail to work."
        },
        {
          "id": 276,
          "identifier": "rocky-payload",
          "flavorText": "Powers up Rock-type moves."
        },
        {
          "id": 277,
          "identifier": "wind-power",
          "flavorText": "The Pokémon becomes charged when it is hit by a wind move, boosting the power of the next Electric-type move the Pokémon uses."
        },
        {
          "id": 278,
          "identifier": "zero-to-hero",
          "flavorText": "The Pokémon transforms into its Hero Form when it switches out."
        },
        {
          "id": 279,
          "identifier": "commander",
          "flavorText": "When the Pokémon enters a battle, it goes inside the mouth of an ally Dondozo if one is on the field. The Pokémon then issues commands from there."
        },
        {
          "id": 280,
          "identifier": "electromorphosis",
          "flavorText": "The Pokémon becomes charged when it takes damage, boosting the power of the next Electric-type move the Pokémon uses."
        },
        {
          "id": 281,
          "identifier": "protosynthesis",
          "flavorText": "Boosts the Pokémon's most proficient stat in harsh sunlight or if the Pokémon is holding Booster Energy."
        },
        {
          "id": 282,
          "identifier": "quark-drive",
          "flavorText": "Boosts the Pokémon's most proficient stat on Electric Terrain or if the Pokémon is holding Booster Energy."
        },
        {
          "id": 283,
          "identifier": "good-as-gold",
          "flavorText": "A body of pure, solid gold gives the Pokémon full immunity to other Pokémon's status moves."
        },
        {
          "id": 284,
          "identifier": "vessel-of-ruin",
          "flavorText": "The power of the Pokémon's ruinous vessel lowers the Sp. Atk stats of all Pokémon except itself."
        },
        {
          "id": 285,
          "identifier": "sword-of-ruin",
          "flavorText": "The power of the Pokémon's ruinous sword lowers the Defense stats of all Pokémon except itself."
        },
        {
          "id": 286,
          "identifier": "tablets-of-ruin",
          "flavorText": "The power of the Pokémon's ruinous wooden tablets lowers the Attack stats of all Pokémon except itself."
        },
        {
          "id": 287,
          "identifier": "beads-of-ruin",
          "flavorText": "The power of the Pokémon's ruinous beads lowers the Sp. Def stats of all Pokémon except itself."
        },
        {
          "id": 288,
          "identifier": "orichalcum-pulse",
          "flavorText": "Turns the sunlight harsh when the Pokémon enters a battle. The ancient pulse thrumming through the Pokémon also boosts its Attack stat in harsh sunlight."
        },
        {
          "id": 289,
          "identifier": "hadron-engine",
          "flavorText": "Turns the ground into Electric Terrain when the Pokémon enters a battle. The futuristic engine within the Pokémon also boosts its Sp. Atk stat on Electric Terrain."
        },
        {
          "id": 290,
          "identifier": "opportunist",
          "flavorText": "If an opponent's stat is boosted, the Pokémon seizes the opportunity to boost the same stat for itself."
        },
        {
          "id": 291,
          "identifier": "cud-chew",
          "flavorText": "When the Pokémon eats a Berry, it will regurgitate that Berry at the end of the next turn and eat it one more time."
        },
        {
          "id": 292,
          "identifier": "sharpness",
          "flavorText": "Powers up slicing moves."
        },
        {
          "id": 293,
          "identifier": "supreme-overlord",
          "flavorText": "When the Pokémon enters a battle, its Attack and Sp. Atk stats are slightly boosted for each of the allies in its party that have already been defeated."
        },
        {
          "id": 294,
          "identifier": "costar",
          "flavorText": "When the Pokémon enters a battle, it copies an ally's stat changes."
        },
        {
          "id": 295,
          "identifier": "toxic-debris",
          "flavorText": "Scatters poison spikes at the feet of the opposing team when the Pokémon takes damage from physical moves."
        },
        {
          "id": 296,
          "identifier": "armor-tail",
          "flavorText": "The mysterious tail covering the Pokémon's head makes opponents unable to use priority moves against the Pokémon or its allies."
        },
        {
          "id": 297,
          "identifier": "earth-eater",
          "flavorText": "If hit by a Ground-type move, the Pokémon has its HP restored instead of taking damage."
        },
        {
          "id": 298,
          "identifier": "mycelium-might",
          "flavorText": "The Pokémon will always act more slowly when using status moves, but these moves will be unimpeded by the Ability of the target."
        },
        {
          "id": 299,
          "identifier": "minds-eye",
          "flavorText": "The Pokémon ignores changes to opponents' evasiveness, its accuracy can't be lowered, and it can hit Ghost types with Normal-type and Fighting-type moves"
        },
        {
          "id": 300,
          "identifier": "supersweet-syrup",
          "flavorText": "Lowers the evasion of opposing Pokémon by 1 stage when first sent into battle"
        },
        {
          "id": 301,
          "identifier": "hospitality",
          "flavorText": "When the Pokémon enters a battle, it showers its ally with hospitality, restoring a small amount of the ally's HP"
        },
        {
          "id": 302,
          "identifier": "toxic-chain",
          "flavorText": "The power of the Pokémon's toxic chain may badly poison any target the Pokémon hits with a move"
        },
        {
          "id": 303,
          "identifier": "embody-aspect",
          "flavorText": "The Pokémon's heart fills with memories, causing the Mask to shine and one of the Pokémon's stats to be boosted."
        },
        {
          "id": 304,
          "identifier": "tera-shift",
          "flavorText": "When the Pokémon enters a battle, it absorbs the energy around itself and transforms into its Terastal Form."
        },
        {
          "id": 305,
          "identifier": "tera-shell",
          "flavorText": "The Pokémon's shell contains the powers of each type. All damage-dealing moves that hit the Pokémon when its HP is full will not be very effective."
        },
        {
          "id": 306,
          "identifier": "teraform-zero",
          "flavorText": "When Terapagos changes into its Stellar Form, it uses its hidden powers to eliminate all effects of weather and terrain, reducing them to zero."
        },
        {
          "id": 307,
          "identifier": "poison-puppeteer",
          "flavorText": "Pokémon poisoned by Pecharunt's moves will also become confused."
        }
      ]

    return abilities
}