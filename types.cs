//basic tooltip construction, separated out so I can use it in menus for things besides items.
struct tooltip
{
    int tooltipID;
    string tooltip;
    int languageID;
}

//generic construction for effects. item effects, spell effects, status conditions, duration
class Effect
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
    public virtual Effect(){}
}

//generic construction for items. equipment, keys, consumables, 
//whether it's cursed or not, whether it's been identified or not
struct item
{
    int quantity;
    int cost;
    enum itemType
    {
        CONSUMABLE,
        CONSUMABLE_FOOD, //breaking this one out specifically in case I want to do something crunchy with it.
        EQUIPMENT_WEAPON,
        EQUIPMENT_ARMOR,
        KEY
    };
    enum equipType
    {
        NOT_EQUIPMENT,
        SWORD,
        KATANA,
        BOW,
        STAFF,
        BOOK,
        GUN,
        MONSTER_WEAPON,
        LIGHT_ARMOR,
        MEDIUM_ARMOR,
        HEAVY_ARMOR,
        HELMET,
    }
    bool cursed;
    bool identified;
    Effect itemEffect;
}

//struct for spells. spells are just a level and effect. 
struct spell
{
    int spellLevel;
    Effect spellEffect;
}

[System.Serializable()]
struct job
{
    string jobName;
    int level;
    enum xpCurve
    {
        SLOW, NORMAL, FAST
    };
    enum jobTypes
    {
        FIGHTER, //better at avoiding hits, good with most weapons
        WIZARD, //terrible at avoiding hits, good at identifying traps, can cast all the cool spells.
        MAGIC_DOCTOR, //man that piece of worldbuilding from dungeon meshi was neat. i should add a bmi stat to make it easier to tell if a revive spell will work. there's probably some interesting subsystems i could put in because of it too.
        THIEF, //good at opening chests and not much else. would be a crack shot if you could find a gun...
        TRAVELER, //all-rounder. can fight and cast spells. all of their spells are in other languages
        CHEMIST, //i am not smart enough to implement !mix but it would be sick
        MUSICIAN, //can buff the party and debuff the enemy and use the power of rock and roll
        SAMURAI, //samurai can equip swords to both hand slots and their head slot.
        CHIMERA, //if i could figure out how to make it work i'd say this one can absorb monsters like it's SaGa.
        CALCULATOR, //can directly modify memory values once a turn. insanely strong if you know what you're doing. terrible otherwise.
        CHEF, //can make food out of monsters. handy to have in longer expeditions.
        //all of the ones below this point are enemy classes
        MONSTER_WEAK,
        MONSTER_AVERAGE,
        MONSTER_STRONG,
        LOW_LEVEL_DUNGEON_MANAGER,
        MID_LEVEL_DUNGEON_MANAGER,
        HIGH_POWERED_DUNGEON_EXECUTIVE
    }
    Dictionary<int, spell> spellsToLearn;
    Dictionary<int, int[]> newSpellSlotsPerLevel;
    int[] statRequirements;
    enum proficiencyLevel
    {
        S, A, B, C, D, E, F
    }
    Dictionary<item.equipType, proficiencyLevel> equipmentProficiency;
        Effect.element[] elementalWeaknesses;
    Effect.effectType[] typeWeaknesses;
    Effect.element[] elementalResistances;
    Effect.effectType[] typeResistances;
    //a bunch more things tbd
}

//basic character construction. inventory, level, gold, name, job, stats, spells, spell slots, equipped gear, statuses effecting them
[System.Serializable()]
struct character
{
    int id;
    string characterName;
    List<job> characterJob;
    int hp;
    int xp;
    int gold;
    int strength; int strMod;
    int intelligence; int intMod;
    int constitution; int conMod;
    int dexterity; int dexMod;
    int luck; int luckMod;
    int bmi;
    int AC;
    bool isAlive;
    List<item> inventory;
    List<spell> spellsKnown;
    int[] spellSlots;
    item[] equipment;
    List<Effect> conditions;
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
    bool enemy; //enemy: true. player: false. this is just to tell the game which side the units are on when setting up the fight.
}

//container for processing actions in combat
struct action
{
    character attacker;
    character target;
    Effect effectToBeApplied;
}

public void ApplyEffect(action info)
{
    info.effectToBeApplied.Effect(info.attacker, info.target);
}
