
//alright, we've got all the types stubbed out, let's try stubbing out the combat form
class BattleManager
{
    List<character> defeatedEnemies;
    party playerParty;
    encounter enemyEncounter;
    bool isEndOfEncounter;
    List<action> actionQueue;

    BattleManager(party player, encounter enemy)
    {
        playerParty = player;
        enemyEncounter = enemy;
        isEndOfEncounter = false;
        actionQueue = new List<action>();
        defeatedEnemies = new List<character>();
        currentPhase = battlePhase.BATTLE_START;
    }
    enum battlePhase
    {
        BATTLE_START
        PLAYER_ACTION,
        PROCESS_PLAYER_ACTIONS,
        CHECK_PLAYER_WIN
        ENEMY_ACTION,
        PROCESS_ENEMY_ACTIONS,
        CHECK_ENEMY_WIN,
        BATTLE_END
    }
    battlePhase currentPhase;

    void addActionToQueue(action move)
    {
        actionQueue.Add(move);
    }
    void processActions()
    {
        
    }

    private void moveToNextPhase()
    {

    }

    bool checkEndOfEncounter()
    {
        for (int i=0; i<enemyEncounter.encounter.Length; i++)
        {
            for(int j=0; j<enemyEncounter.encounter[i].party.Length;j++)
            {
                if(enemyEncounter.encounter[i].party[j].isAlive)
                {
                    return false;
                }
            }
        }
        for(int i=0; i<playerParty.Length;i++)
        {
            if(playerParty[i].isAlive)
            {
                return false;
            }
        }
        return true;
    }

    void ProcessEndOfEncounter()
    {
        int totalgold = 0;
        int totalXP = 0;
        for(int i=0; i<defeatedEnemies.Count;i++)
        {
            gold += defeatedEnemies[i].gold;
            totalXP += defeatedEnemies[i].xp;
        }
        int numberOfLivingPlayerPartyMembers = 0;
        for(int i=0; i<playerParty.Count;i++)
        {
            if(playerParty[i].isAlive)
            {
                numberOfLivingPlayerPartyMembers++;
            }
        }
        if(numberOfLivingPlayerPartyMembers > 0)
        {
            totalgold = totalgold / numberOfLivingPlayerPartyMembers;
            totalXP = totalXP / numberOfLivingPlayerPartyMembers;
            for(int i=0; i<playerParty.Count;i++)
            {
                if(playerParty[i].isAlive)
                {
                    playerParty[i].gold += totalgold;
                    playerParty[i].xp += totalXP;
                }
            }
            currentPhase = battlePhase.BATTLE_END;
        }
        else
        {
            currentPhase = battlePhase.BATTLE_END;
        }
    }
}
