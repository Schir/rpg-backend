private gameStates currentState = gameStates.TITLE;

public static int main()
{
    //alright how does this all work again
    //i guess I'll just stub out the basic kind of structure of this sort of thing
    party playerParty;
    while(currentState != gameStates.EXIT)
    {
        switch(currentState)
        {
        case gameStates.TITLE:
            drawTitle();
            int selectedOption = getTitleSelection();
            currentState = switchTitleState(selectedOption, currentState);
            break;
        case gameStates.NEWGAME:
            playerParty = new party();
            currentState = currentState.GAME;
            break;
        case gameStates.LOADGAME:
            playerParty = LoadGame();
            currentState = currentState.GAME;
            break;
        case currentState.GAME:
            coreGameLoop();
            break;
        }
    }
    if(currentState == gameStates.EXIT)
    {
        return 0;
    }
}
enum gameStates
{
    SPLASH,
    TITLE,
    NEWGAME,
    LOADGAME,
    GAME,
    EXIT
}
