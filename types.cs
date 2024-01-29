

/*
alright let's see here

so first off I probably want a basic character class


*/


struct effect
{
    int id;
    int effectID;
    string name;
    string alias;
    int tooltipID;
    string tooltip;
}

struct item
{
    int quantity;
    int cost;
    enum type
    {
        CONSUMABLE,
        EQUIPMENT_HEAD,
        EQUIPMENT_HAND,
        EQUIPMENT_ARMOR,
        KEY
    };
    effect itemEffect;
}

enum job
{
    FIGHTER,
    WIZARD,
    MAGIC_DOCTOR,
    THIEF,
    TIME_TRAVELER, 
    CHEMIST,
    CHIMERA,
    MONSTER_WEAK,
    MONSTER_AVERAGE,
    MONSTER_STRONG,
    DUNGEON_MANAGER
};




struct Character
{
    int hp;
    int xp;
    string characterName;
    int id;
    job characterJob;
    
}
