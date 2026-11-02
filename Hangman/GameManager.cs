using System;

namespace Hangman;

public static class GameManager
{
    public static void Begin()
    {
        Game game = new Game();
        game.Setup();
        game.Start();
        if(game.End()) Begin();
    }
}