namespace Hangman;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        ConsoleWriter.WriteLine("Enter number of attempts:", ConsoleColor.Magenta);
        string? input = Console.ReadLine();
        if(!int.TryParse(input, out int s)) s = 5;
        Game game = new Game(s);
        game.Start();
    }
}
