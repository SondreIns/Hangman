namespace Hangman;

public class Game
{
    public Word Word { get; }
    public string ChosenWord => Word.ChosenWord;
    public int WordLength => Word.Length;

    private string _attempt = "";
    private string _used = "", _correct = "", _incorrect = ""; 

    public Game()
    {
        Word = new Word();
    }

    public void Round()
    {
        
    }

    private bool CheckLetter(char l) => Word.IsAccepted(l);

    private void SetupConsole()
    {
        Console.Clear();
        
    }

}