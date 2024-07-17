
export function getAllPokemon() {
    const pokemon = [
            {
                "id": 1,
                "identifier": "bulbasaur",
                "speciesId": 1,
                "types": [
                    "grass",
                    "poison"
                ],
                "genders": [
                    "female",
                    "male"
                ],
                "abilities": [
                    {
                    "identifier": "overgrow",
                    "flavorText": "Powers up Grass-type moves when the Pokémon's HP is low."
                    },
                    {
                    "identifier": "chlorophyll",
                    "flavorText": "Boosts the Pokémon's Speed stat in harsh sunlight."
                    }
                ],
                "baseStats": {
                    "hp": 45,
                    "attack": 49,
                    "defense": 49,
                    "specialAttack": 65,
                    "specialDefense": 65,
                    "speed": 45
                }
            },
            {
                "id": 2,
                "identifier": "ivysaur",
                "speciesId": 2,
                "types": [
                    "grass",
                    "poison"
                ],
                "genders": [
                    "female",
                    "male"
                ],
                "abilities": [
                    {
                    "identifier": "overgrow",
                    "flavorText": "Powers up Grass-type moves when the Pokémon's HP is low."
                    },
                    {
                    "identifier": "chlorophyll",
                    "flavorText": "Boosts the Pokémon's Speed stat in harsh sunlight."
                    }
                ],
                "baseStats": {
                    "hp": 60,
                    "attack": 62,
                    "defense": 63,
                    "specialAttack": 80,
                    "specialDefense": 80,
                    "speed": 60
                }
            },
            {
                "id": 3,
                "identifier": "venusaur",
                "speciesId": 3,
                "types": [
                    "grass",
                    "poison"
                ],
                "genders": [
                    "female",
                    "male"
                ],
                "abilities": [
                    {
                    "identifier": "overgrow",
                    "flavorText": "Powers up Grass-type moves when the Pokémon's HP is low."
                    },
                    {
                    "identifier": "chlorophyll",
                    "flavorText": "Boosts the Pokémon's Speed stat in harsh sunlight."
                    }
                ],
                "baseStats": {
                    "hp": 80,
                    "attack": 82,
                    "defense": 83,
                    "specialAttack": 100,
                    "specialDefense": 100,
                    "speed": 80
                }
            },
            {
                "id": 4,
                "identifier": "charmander",
                "speciesId": 4,
                "types": [
                    "fire"
                ],
                "genders": [
                    "female",
                    "male"
                ],
                "abilities": [
                    {
                    "identifier": "blaze",
                    "flavorText": "Powers up Fire-type moves when the Pokémon's HP is low."
                    },
                    {
                    "identifier": "solar-power",
                    "flavorText": "In harsh sunlight, the Pokémon's Sp. Atk stat is boosted, but its HP decreases every turn."
                    }
                ],
                "baseStats": {
                    "hp": 39,
                    "attack": 52,
                    "defense": 43,
                    "specialAttack": 60,
                    "specialDefense": 50,
                    "speed": 65
                }
            },
            {
                "id": 5,
                "identifier": "charmeleon",
                "speciesId": 5,
                "types": [
                    "fire"
                ],
                "genders": [
                    "female",
                    "male"
                ],
                "abilities": [
                    {
                    "identifier": "blaze",
                    "flavorText": "Powers up Fire-type moves when the Pokémon's HP is low."
                    },
                    {
                    "identifier": "solar-power",
                    "flavorText": "In harsh sunlight, the Pokémon's Sp. Atk stat is boosted, but its HP decreases every turn."
                    }
                ],
                "baseStats": {
                    "hp": 58,
                    "attack": 64,
                    "defense": 58,
                    "specialAttack": 80,
                    "specialDefense": 65,
                    "speed": 80
                }
            },
            {
                "id": 6,
                "identifier": "charizard",
                "speciesId": 6,
                "types": [
                    "fire",
                    "flying"
                ],
                "genders": [
                    "female",
                    "male"
                ],
                "abilities": [
                    {
                    "identifier": "blaze",
                    "flavorText": "Powers up Fire-type moves when the Pokémon's HP is low."
                    },
                    {
                    "identifier": "solar-power",
                    "flavorText": "In harsh sunlight, the Pokémon's Sp. Atk stat is boosted, but its HP decreases every turn."
                    }
                ],
                "baseStats": {
                    "hp": 78,
                    "attack": 84,
                    "defense": 78,
                    "specialAttack": 109,
                    "specialDefense": 85,
                    "speed": 100
                }
            },
            {
                "id": 16,
                "identifier": "pidgey",
                "speciesId": 16,
                "types": [
                  "normal",
                  "flying"
                ],
                "genders": [
                  "female",
                  "male"
                ],
                "abilities": [
                  {
                    "identifier": "keen-eye",
                    "flavorText": "The Pokémon's keen eyes prevent its accuracy from being lowered."
                  },
                  {
                    "identifier": "tangled-feet",
                    "flavorText": "Boosts the Pokémon's evasiveness if it is confused."
                  },
                  {
                    "identifier": "big-pecks",
                    "flavorText": "Prevents the Pokémon from having its Defense stat lowered."
                  }
                ],
                "baseStats": {
                  "hp": 40,
                  "attack": 45,
                  "defense": 40,
                  "specialAttack": 35,
                  "specialDefense": 35,
                  "speed": 56
                }
              },
    ]

    return pokemon;
}