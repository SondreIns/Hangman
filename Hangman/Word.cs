namespace Hangman;

public class Word
{
    public string ChosenWord { get; }
    public char[] AcceptableLetter  {get; } = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                                               'N' ,'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    public int Length => ChosenWord.Length;
    private string[] words = {"Andromeda", "Baffled", "Chasing"};

    public Word()
    {
        ChosenWord = words[new Random().Next(0, words.Length)];
    }

    public bool IsAccepted(char letter)
    {
        return AcceptableLetter.Contains(char.ToUpper(letter));
    }
}