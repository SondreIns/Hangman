namespace Hangman;

public class Word
{
    public string ChosenWord { get; }
    public int Length => ChosenWord.Length;
    private string[] words = {"Andromeda", "Baffled", "Chasing"};

    public Word()
    {
        ChosenWord = words[new Random().Next(0, words.Length)];
    }
}