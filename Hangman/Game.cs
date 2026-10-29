namespace Hangman;

public class Game
{
    public Word Word { get; }
    public string ChosenWord => Word.ChosenWord;
    public int WordLength => Word.Length;

    private string _attempt = "";
    private string _used = "", _correct = "ABC", _incorrect = "";
    private int _maxAttempts, _currentAttempts = 0;

    public Game(int numAttempts)
    {
        Word = new Word();
        _maxAttempts = numAttempts;
    }

    public void Start()
    {
        while (_currentAttempts < _maxAttempts)
        {
            Round();
        }
    }

    private void Round()
    {
        SetupConsole();
        InputRound();
    }

    private void InputRound()
    {
        string? input = Console.ReadLine();
        char l = char.ToUpper(input[0]);
        if (!CheckLetter(l)) InputRound();
        else
        {
            _used += l;
            Evaluate(l);
            _currentAttempts++;
        }
    }

    private void Evaluate(char l)
    {
        bool correct = false;
        foreach(char letter in ChosenWord)
        {
            if(l == letter)
            {
                correct = true;
                break;
            }
        }

        if(correct) _correct += l;
        else _incorrect += l;
    }

    private bool CheckLetter(char l)
    {
        return !_used.Contains(l) && Word.IsAccepted(l);
    }

    private void SetupConsole()
    {
        Console.Clear();
        BuildUI();
    }

    private void BuildUI()
    {
        ConsoleWriter.Write(BuildString(), ConsoleColor.Green);
        ConsoleWriter.Write(" | ", ConsoleColor.White);
        ConsoleWriter.Write($"Attempt: {_currentAttempts} / {_maxAttempts}", ConsoleColor.Cyan);
        ConsoleWriter.Write(" | ", ConsoleColor.White);
        ConsoleWriter.Write("Incorrect: ", ConsoleColor.Yellow);
        ConsoleWriter.Write(_incorrect, ConsoleColor.Red);
        Console.WriteLine();
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