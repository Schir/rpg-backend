//basic tooltip construction, separated out so I can use it in menus for things besides items.
struct tooltip
{
    int tooltipID;
    string tooltip;
    int languageID;
}

//generic construction for effects. item effects, spell effects, status conditions, duration
struct effect
{
    int id;
    int effectID;
    string name;
    string alias;
    tooltip whatItDoes;
    enum element
    {
        METAL,
        FIRE,
        WIND,
        ICE,
        ELECTRICITY,
        NUCLEAR,
        ROCK, //for the record this is both rock (stone) and rock (rock'n'roll). musicians do this type of damage.
        HOLY
    }
    enum effectType
    {
        BLUNT,
        PIERCE,
        SLASH,
        EXPLOSIVE,
        MENTAL,
        HEAL,
        BUFF,
        DEBUFF
    };
    enum range
    {
        CHARACTER,
        PARTY,
        ENCOUNTER
    };
    int duration;
}

//generic construction for items. equipment, keys, consumables, 
//whether it's cursed or not, whether it's been identified or not
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
    bool cursed;
    bool identified;
    effect itemEffect;
}

//struct for spells. spells are just a level and effect. 
struct spell
{
    int spellLevel;
    effect spellEffect;
}

struct job
{
    string jobName;
    enum xpCurve
    {
        SLOW,
        NORMAL,
        FAST
    };
    enum jobTypes
    {
        FIGHTER,
        WIZARD,
        MAGIC_DOCTOR,
        THIEF,
        TIME_TRAVELER, 
        CHEMIST,
        MUSICIAN,
        CHIMERA,
        MONSTER_WEAK,
        MONSTER_AVERAGE,
        MONSTER_STRONG,
        LOW_LEVEL_DUNGEON_MANAGER,
        MID_LEVEL_DUNGEON_MANAGER,
        HIGH_POWERED_DUNGEON_EXECUTIVE
    }
    //a bunch more things tbd
}

//basic character construction. inventory, level, gold, name, job, stats, spells, spell slots, equipped gear, statuses effecting them
struct character
{
    int id;
    string characterName;
    job characterJob;
    int level;
    int hp;
    int xp;
    int muscle;
    int studiousness;
    int constitution;
    int nimbleness;
    int luck;
    item[] inventory;
    spell[] spellsKnown;
    int[] spellSlots;
    item[] equipment;
    effect[] conditions;
}

//basic grouping of units.
struct party
{
    character[] party;
}

//encounters will be against multiple groups of enemies like in dragon quest and wizardry
struct encounter
{
    party[] encounter;
    bool enemy; //enemy: true. player: false. this is just to tell the game which side the units are on.
}

//container for processing actions in combat
struct action
{
    character attacker;
    party target;
    effect effectToBeApplied;
}
