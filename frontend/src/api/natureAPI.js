export function getAllNatures() {
    const   natures = [
        {
          "id": 1,
          "identifier": "hardy",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        },
        {
          "id": 2,
          "identifier": "bold",
          "attackMultiplier": 0.9,
          "defenseMultiplier": 1.1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        },
        {
          "id": 3,
          "identifier": "modest",
          "attackMultiplier": 0.9,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1.1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        },
        {
          "id": 4,
          "identifier": "calm",
          "attackMultiplier": 0.9,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1.1,
          "speedMultiplier": 1
        },
        {
          "id": 5,
          "identifier": "timid",
          "attackMultiplier": 0.9,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1.1
        },
        {
          "id": 6,
          "identifier": "lonely",
          "attackMultiplier": 1.1,
          "defenseMultiplier": 0.9,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        },
        {
          "id": 7,
          "identifier": "docile",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        },
        {
          "id": 8,
          "identifier": "mild",
          "attackMultiplier": 1,
          "defenseMultiplier": 0.9,
          "specialAttackMultiplier": 1.1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        },
        {
          "id": 9,
          "identifier": "gentle",
          "attackMultiplier": 1,
          "defenseMultiplier": 0.9,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1.1,
          "speedMultiplier": 1
        },
        {
          "id": 10,
          "identifier": "hasty",
          "attackMultiplier": 1,
          "defenseMultiplier": 0.9,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1.1
        },
        {
          "id": 11,
          "identifier": "adamant",
          "attackMultiplier": 1.1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 0.9,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        },
        {
          "id": 12,
          "identifier": "impish",
          "attackMultiplier": 1,
          "defenseMultiplier": 1.1,
          "specialAttackMultiplier": 0.9,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        },
        {
          "id": 13,
          "identifier": "bashful",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        },
        {
          "id": 14,
          "identifier": "careful",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 0.9,
          "specialDefenseMultiplier": 1.1,
          "speedMultiplier": 1
        },
        {
          "id": 15,
          "identifier": "rash",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1.1,
          "specialDefenseMultiplier": 0.9,
          "speedMultiplier": 1
        },
        {
          "id": 16,
          "identifier": "jolly",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 0.9,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1.1
        },
        {
          "id": 17,
          "identifier": "naughty",
          "attackMultiplier": 1.1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 0.9,
          "speedMultiplier": 1
        },
        {
          "id": 18,
          "identifier": "lax",
          "attackMultiplier": 1,
          "defenseMultiplier": 1.1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 0.9,
          "speedMultiplier": 1
        },
        {
          "id": 19,
          "identifier": "quirky",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        },
        {
          "id": 20,
          "identifier": "naive",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 0.9,
          "speedMultiplier": 1.1
        },
        {
          "id": 21,
          "identifier": "brave",
          "attackMultiplier": 1.1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 0.9
        },
        {
          "id": 22,
          "identifier": "relaxed",
          "attackMultiplier": 1,
          "defenseMultiplier": 1.1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 0.9
        },
        {
          "id": 23,
          "identifier": "quiet",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1.1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 0.9
        },
        {
          "id": 24,
          "identifier": "sassy",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1.1,
          "speedMultiplier": 0.9
        },
        {
          "id": 25,
          "identifier": "serious",
          "attackMultiplier": 1,
          "defenseMultiplier": 1,
          "specialAttackMultiplier": 1,
          "specialDefenseMultiplier": 1,
          "speedMultiplier": 1
        }
      ];

    return natures;
}