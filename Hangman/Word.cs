namespace Hangman;

public class Word
{
    public string ChosenWord { get; }
    public char[] AcceptableLetter  {get; } = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                                               'N' ,'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    public int Length => ChosenWord.Length;
    private string[] words = {
        "ANDROMEDA", "AGITATED", "ANTAGONIST", "BAFFLED", "BOATSWAIN", "BAILIFF", "CHASING", "CRYONIC", "CUISINE", "DAWNING", 
        "DREG", "DISCIPLINE", "ENTITY", "ERASURE", "EPOCH", "FORGOTTEN", "FLAIR", "FURIOUS", "GANTRIES", "GULLIBLE", "GUNWALE", 
        "HEDONISM", "HUNTER", "HOLLOW", "INCANDESCENT", "IRRITABLE", "ILLNESS", "JOVIAL", "JADED", "JOINT", "KEROSENE", "KINGDOM", 
        "KNAVE", "LAMENTABLE", "LOITER", "LARYNX", "MISSIVE", "MAROON", "MOLD", "NATURAL", "NEFARIOUS", "NITPICK", "OILED", "OPULENT", 
        "ORGANIST", "PARASITE", "PTERODACTYL", "PNEUMONIC", "QUERY", "QUAFF", "QUINTESSENTIAL", "RANCID", "RUPTURE", "RENTING", "SENTIENT", 
        "SOLILOQUY", "SHARE", "TOTAL", "TERRAIN", "TINNITUS", "UNDERSTANDING", "UPRISING", "ULTIMATUM", "VINTNER", "VALUE", "VORACIOUS", 
        "WHARF", "WOOLY", "WANTON", "XENOPHOBIC", "XYLOPHONE", "XANADU", "YEARNING", "YULE", "YELPING", "ZEITGEIST", "ZONING", "ZENITH"};

    public Word()
    {
        ChosenWord = words[new Random().Next(0, words.Length)];
    }

    public bool IsAccepted(char letter)
    {
        return AcceptableLetter.Contains(char.ToUpper(letter));
    }
}