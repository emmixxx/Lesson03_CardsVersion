namespace Toolkit.Rules;



//Defense:
/*
To shuffle, I split the deck of cards in half, hold each half in one hand, and let the cards interweave from both halves.
"var half = deck.Split();" creates one half of the deck of cards (the other half is just deck)
"Deck result = Deck.CreateEmpty(); " - calling result a brand new, empty deck
" while (half.Count > 0 && deck.Count > 0) //&& means both conditions are true
           
              var count1 = random.Next(1, 4);
   result.AddCardsOnBottom(half.Deal(count1));

   var count2 = random.Next(1, 4);
       result.AddCardsOnBottom(deck.Deal(count2));
       
    Meaning: when both halves of the deck are not empty (have > 0 cards) after you begin interweaving, you add count1 (giving a random number (from 1-4) of cards) from half to result and add count2 from deck to result
    
    " if (half.Count > 0)
                  result.AddCardsOnBottom(half.Deal(half.Count));

              if (deck.Count > 0)
                  result.AddCardsOnBottom(deck.Deal(deck.Count));"

    Meaning: if only one half has cards remaining (>0), deal all the remaining cards into the result pile

    " deck.AddCardsOnBottom(result.Deal(result.Count));" - put all the cards back into the now-empty deck

    A way that the code differs from a person is that although this code randomly interweaves cards from both halves, it only gives 1-4 cards, rather than real life, where this "randomness" could be more random in the number of cards dealt
    
   I added CreateEmpty() to Deck, because Deck, rather than ShuffleAlgorithms, should handle building a Deck from scratch
   
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
        deck.AddCardsOnBottom(cards);
    }
    public static void Riffle(Deck deck, Random random)
    {
        
        var half = deck.Split();
        Deck result = Deck.CreateEmpty(); 

            while (half.Count > 0 && deck.Count > 0) //&& means both conditions are true
            {
                var count1 = random.Next(1, 4);
                result.AddCardsOnBottom(half.Deal(count1));

                var count2 = random.Next(1, 4);
                    result.AddCardsOnBottom(deck.Deal(count2));
               
            }
            
            if (half.Count > 0)
                result.AddCardsOnBottom(half.Deal(half.Count));
            
            if (deck.Count > 0)
                result.AddCardsOnBottom(deck.Deal(deck.Count));

            deck.AddCardsOnBottom(result.Deal(result.Count));


    }
        
}

