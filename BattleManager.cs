
//alright, we've got all the types stubbed out, let's try stubbing out the combat form
class BattleManager
{
    character[] defeatedEnemies;
    party playerParty;
    encounter enemyEncounter;
    bool isEndOfEncounter;
    action[] actionQueue;

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

    

    void ProcessEndOfEncounter()
    {
        int totalgold = 0;
        int totalXP = 0;
        for(int i=0; i<defeatedEnemies.Length;i++)
        {
            gold += defeatedEnemies[i].gold;
            totalXP += defeatedEnemies[i].xp;
        }
        int numberOfLivingPlayerPartyMembers = 0;
        for(int i=0; i<playerParty.Length;i++)
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
            for(int i=0; i<playerParty.Length;i++)
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
