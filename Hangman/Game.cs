namespace Hangman;

public class Game
{
    public Word Word { get; }
    public string ChosenWord => Word.ChosenWord;
    public int WordLength => Word.Length;

    private string _attempt = "";
    private string _used = "", _correct = "ABC", _incorrect = "";

    public Game()
    {
        Word = new Word();
    }

    public void Round()
    {
        ConsoleWriter.WriteLine(BuildString(), ConsoleColor.Green);
    }

    private bool CheckLetter(char l) => Word.IsAccepted(l);

    private void SetupConsole()
    {
        Console.Clear();
    }

    private string BuildString()
    {
        string result = "";
        foreach (char l in ChosenWord)
        {
            bool correct = false;
            foreach (char le in _correct)
            {
                if (l == le)
                {
                    result += le;
                    correct = true;
                }
                if(correct) break;
            }
            if (!correct) result += '_';
        }
        return result;
    }

}