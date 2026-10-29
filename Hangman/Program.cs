namespace Hangman;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game(5);
        game.Start();
    }
}
