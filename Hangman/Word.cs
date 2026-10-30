namespace Hangman;

public class Word
{
    public string ChosenWord { get; }
    public char[] AcceptableLetter  {get; } = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                                               'N' ,'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    public int Length => ChosenWord.Length;
    private string[] words = {
        "ANDROMEDA", "AGITATED", "BAFFLED", "BOUNCY", "CHASING", "CRYONIC", "DAWNING", "DREG", "ENTITY", "ERASURE",
        "FORGOTTEN", "FLAIR", "GANTRIES", "GULLIBLE", "HEDONISM", "HUNTER", "INCANDESCENT", "IRRITABLE", "JOVIAL", 
        "JADED", "KEROSENE", "KINGDOM", "LAMENTABLE", "LOITER", "MISSIVE", "MAROON", "NATURAL", "NEFARIOUS", "OILED",
        "OPULENT, PARASITE", "PTERODACTYL", "QUERY", "QUAFF", "RANCID", "RUPTURE", "SENTIENT", "SOLILOQUY", "TOTAL",
        "TERRAIN", "UNDERSTANDING", "UPRISING", "VINTNER", "VALUE", "WHARF", "WOOLY", "XENOPHOBIC", "XYLOPHONE", "YEARNING",
        "YULE", "ZEITGEIST", "ZONING"};

    public Word()
    {
        ChosenWord = words[new Random().Next(0, words.Length)];
    }

    public bool IsAccepted(char letter)
    {
        return AcceptableLetter.Contains(char.ToUpper(letter));
    }
}