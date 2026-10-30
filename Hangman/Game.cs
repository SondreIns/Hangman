namespace Hangman;

public class Game
{
    public Word Word { get; }
    public string ChosenWord => Word.ChosenWord;
    public int WordLength => Word.Length;

    private string _used = "", _correct = "", _incorrect = "";
    private int _numCorrect = 0, _maxAttempts, _currentAttempts = 0;

    public Game()
    {
        Word = new Word();
    }

    public void Setup()
    {
        Console.Clear();
        ConsoleWriter.WriteLine("Enter number of attempts:", ConsoleColor.Magenta);
        string? input = Console.ReadLine();
        if (!int.TryParse(input, out int numAttempts)) numAttempts = 5;
        if (numAttempts > 10) numAttempts = 10;
        else if (numAttempts < 1) numAttempts = 1;
        _maxAttempts = numAttempts;
    }

    public void Start()
    {
        bool finished = false;
        while (!finished)
        {
            Round();
            BuildString();
            finished = CheckFinish();
        }
        Console.Clear();
        BuildUI();
        if(_numCorrect == WordLength)
            ConsoleWriter.WriteLine("Winner winner chicken dinner", ConsoleColor.Green);
        else
        {
            ConsoleWriter.WriteLine("Loser loser goose loser", ConsoleColor.Red);
            ConsoleWriter.Write("The correct word was ", ConsoleColor.Cyan);
            ConsoleWriter.Write(ChosenWord + "\n", ConsoleColor.Yellow);
        }
           
        Console.ReadKey();
    }

    private void Round()
    {
        SetupConsole();
        InputRound();
    }

    private void InputRound()
    {
        string? input = Console.ReadLine();
        if(input == string.Empty || input == null) input = "å";
        char l = char.ToUpper(input[0]);
        if (!CheckLetter(l))
        {
            ConsoleWriter.WriteLine("Enter a valid, unused character", ConsoleColor.DarkRed);
            InputRound();
        }
        else
        {
            _used += l;
            Evaluate(l);
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
        else 
        {
            _incorrect += l;
            _currentAttempts++;
        }
    }

    private bool CheckFinish()
    {
        return _currentAttempts >= _maxAttempts || _numCorrect == WordLength;
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
        _numCorrect = 0;
        foreach (char l in ChosenWord)
        {
            bool correct = false;
            foreach (char le in _correct)
            {
                if (l == le)
                {
                    result += le;
                    correct = true;
                    _numCorrect++;
                }
                if(correct) break;
            }
            if (!correct) result += '_';
        }
        return result;
    }

}