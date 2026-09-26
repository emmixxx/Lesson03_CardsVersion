namespace Toolkit;

public record Deck
{
    public static Deck CreateStandardDeck() => new Deck(); //factory method - guarantee that you create a valid instance of smth
    //impossible to create an invalid deck through "CreateStandardDeck"

    private readonly List<Card> _cards;

    public Deck(List<Card> fromCards) =>  _cards = fromCards;
    
    private Deck()
    {
        _cards = new List<Card>();
        foreach (var suit in new[] { Suit.Hearts, Suit.Diamonds, Suit.Clubs, Suit.Spades })
        {
            foreach (var value in new[] { Value.Ace, Value.Two, Value.Three, Value.Four, Value.Five, Value.Six, Value.Seven, Value.Eight, Value.Nine, Value.Ten, Value.Jack, Value.Queen, Value.King })
            {
                _cards.Add(new Card(suit, value));
            }
        }
    }

    /// <summary>
    /// Shuffles the deck of cards!
    /// </summary>
    /// <param name="random">Inject your RNG here!</param>
    public void Shuffle(Random random)
    {
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
        }
    }

    public Deck Split()
    {
        Deck other = new Deck(_cards.Take(_cards.Count / 2).ToList());
        _cards.RemoveRange(0, _cards.Count / 2);
        return other;
        //throw new NotImplementedException("Split method is not implemented yet.");
        // TODO: Implement the Split method to return a new Deck with half-ish of the cards.
    }

    public Deck Cut(int numberOfCards)
    {
        Deck other = new Deck(_cards.Take(numberOfCards).ToList());
        _cards.RemoveRange(0, numberOfCards);
        return other;
        //throw new NotImplementedException("Cut method is not implemented yet.");
        // TODO: How is Cut different from Split? 
    }

    public Card DealOne()
    {
        if (_cards.Count == 0)
            throw new InvalidOperationException("No cards left in the deck.");

        var card = _cards[0];
        _cards.RemoveAt(0);
        return card;
    }
    //null - not valid
    //this - self-reference 
    //exception - the exception (special kind of object) that has been thrown
    //stack-like arrangement (void - list - card)

    public List<Card> Deal(int count)
    {
        var dealtCards = new List<Card>();
        for (int i = 0; i < count; i++)
        {
            dealtCards.Add(DealOne());
        }
        return dealtCards;
    }

    public int Count => _cards.Count;
    
    public Card? TopCard => _cards.Count > 0? _cards[0]: null;
}

