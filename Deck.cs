using System.Runtime.InteropServices;
using LanguageExt;

namespace Toolkit;

public record Deck
{
    public static Deck CreateStandardDeck() => new Deck(); //factory method - guarantee that you create a valid instance of smth
    //impossible to create an invalid deck through "CreateStandardDeck"

    private List<Card> _cards;

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
    public void Shuffle(Random random, Action<Deck, Random> shuffleAlgorithm) //Action - can pass a behavior as a variable (function pointers)
    {
        shuffleAlgorithm(this, random); //this is reference too self 
        // shuffle THIS deck of cards using the injected RNG (random number generator)
    }
//  for (int i = _cards.Count - 1; i > 0; i--)
//       {
//           int j = random.Next(i + 1);
//           (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
//           
    public Deck Split()
    {
        Deck other = new Deck(_cards.Take(_cards.Count / 2).ToList());
        _cards.RemoveRange(0, _cards.Count / 2);
        return other;
        //throw new NotImplementedException("Split method is not implemented yet.");
        // TODO: Implement the Split method to return a new Deck with half-ish of the cards.
    }

    public Deck Cut(Random random)
    {
        var cutPoint = random.Next(_cards.Count);
        var otherHalf = new Deck([.. _cards[..cutPoint]]);
        //make cards equal to the part of cards after the cutPoint
        //take away all the cards before cutPoint
        //only use the cards /after/ cutPoint
        _cards = [.. _cards[..cutPoint]]; //list operations are shorthand
        //_cards becomes...
        //       ^[ Collection Expression
        //       ^..take all the items in (below) one by one
        //           _cards[ from _cards
                        // _cards[3..27] upper end is always open set, include bottom end
        //                  ^cutPoint..] starting from index 'cutPoint' to the end
        //                             ^] and that's all
        return otherHalf;
    }
    
    //exceptions: "throw new...exception..."
    //nullable reference: "supply "?"" - thus, for nullable reference, public Card? DealOne()
    //optional/result types: public Optional <Card> DealOne() - Optional is a type (may or may not return Card) that will never return null
    public Card? DealOne()
    {
        if (_cards.Count == 0)
            return null;
            //throw new InvalidOperationException("No cards left in the deck.");

        var card = _cards[0];
        _cards.RemoveAt(0);
        return card;
    }
    //null - not valid
    //this - self-reference 
    //exception - the exception (special kind of object) that has been thrown
    //stack-like arrangement (void - list - card)

    /// <summary>
    /// a new list of cards containing the number of cards requested
    /// OR the number of cards remaining in this Deck.
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<Card> Deal(int count) //each layer of curly brackets is lowering scope
    {
        var dealtCards = new List<Card>();
        for (int i = 0; i < count; i++)
        {
            var card = DealOne();
            if (card is not null)
                dealtCards.Add(card);
            //catching returned card in "Add"


        }
        return dealtCards;
    }

    public int Count => _cards.Count;

    public void
        AddCardsonTop(params List<Card> cards) //params allow deck.ACOT(op)(card), deck.ACOB(ottom) (a,b,c,d) and deck.ACOT(cards)
        => _cards = [..cards, .._cards]; //square brackets for lists
    //says to put cards before current cards

    public void AddCardsonBottom(params List<Card> cards)
        => _cards = [.. _cards, .. cards];

    public void InsertCardsRandomly(Random random, params List<Card> cards)
    {
        var otherHalf = Cut(random);
        // _cards gets the value 
        // _cards followed by the newly added 'cards' then the second half
        _cards = [.. _cards, .. cards, .. otherHalf._cards];

    }
    
    public Card? TopCard => _cards.Count > 0? _cards[0]: null;
}

