namespace Toolkit.Rules;



//Defense:
/*
To shuffle, I split the deck of cards in half, hold each half in one hand, and let the cards interweave from both halves.
"var half = deck.Split();" creates one half of the deck of cards (the other half is just deck)
"List<Card> result = [];" a collection for interweaved cards when they land as riffle
" while (half.Count > 0 && deck.Count > 0) //&& means both conditions are true
              {
                  var card1 = half.DealOne();
                  if (card1 is not null)
                      result.Add(card1);

                  var card2 = deck.DealOne();
                  if (card2 is not null)
                      result.Add(card2);
              }"
    Meaning: when both halves of the deck are not empty (have > 0 cards) after you begin interweaving, and the cards are not nullable, then you add the cards to the result pile

    " if (half.Count > 0)
                  result.AddRange(half.Deal(half.Count));

              if (deck.Count > 0)
                  result.AddRange(deck.Deal(deck.Count));"

    Meaning: if only one half has cards remaining (>0), deal all the remaining cards into the result pile

    " deck.AddCardsonBottom(result);" - put all the cards back into the now-empty deck

    A way that the code differs from a person is that this code generates riffle perfectly every time (double identical cards on top of each other and being even), whereas a real riffle would release unevenly
    
    I did not add any new members to Deck.Split() - DealOne(), Deal(), and AddCardsonBottom() were sufficient
*/
public static class ShuffleAlgorithms //static means you purely create collection of behaviors together under grouping

{
    /// <summary>
    /// shuffles deck using default fisher-yates shuffle algorithm
    /// </summary>
    /// <param name="deck"></param>
    /// <param name="random"></param>
    public static void Default(Deck deck, Random random) //void and parameters in () create Action<Deck,Random>
    {
        //take every card out of the Deck
        var cards = deck.Deal(deck.Count);

        for (int i = cards.Count - 1; i >= 0; i--)
        {
            int j = random.Next(i+1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
        deck.AddCardsonBottom(cards);
    }
    public static void Riffle(Deck deck, Random random)
    {
        var half = deck.Split();
            List<Card> result = [];

            while (half.Count > 0 && deck.Count > 0) //&& means both conditions are true
            {
                var card1 = half.DealOne();
                if (card1 is not null)
                    result.Add(card1);

                var card2 = deck.DealOne();
                if (card2 is not null)
                    result.Add(card2);
            }
            
            if (half.Count > 0)
                result.AddRange(half.Deal(half.Count));
            
            if (deck.Count > 0)
                result.AddRange(deck.Deal(deck.Count));
            
            deck.AddCardsonBottom(result);
    }
        
}

