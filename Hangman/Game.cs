namespace Hangman;

public class Game
{
    public Word Word { get; }
    public string ChosenWord => Word.ChosenWord;
    public int WordLength => Word.Length;

    public Game()
    {
        Word = new Word();
    }

    public void Round()
    {
        
    }

}