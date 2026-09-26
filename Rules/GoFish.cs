namespace Toolkit.Rules.GoFish;

public static class GoFish
{
    extension(Deck deck)
    {
        public void PlayGoFish(Random random)
        {
            List<Card> player1Hand = deck.Deal(5);
            List<Card> player2Hand = deck.Deal(5);

            int player1Books = 0;
            int player2Books = 0;

            while (deck.Count > 0)
            {
                Value asked = player1Hand[0].Value;
                var matches = player2Hand.FindAll(card => card.Value == asked);

                if (matches.Count > 0)
                {
                    player1Hand.AddRange(matches);
                    player2Hand.RemoveAll(card => card.Value == asked);
                }
                else
                {
                    player1Hand.Add(deck.DealOne());
                }

                var books = player1Hand.GroupBy(card => card.Value)
                    .Where(group => group.Count() == 4)
                    .ToList(); //dots represent method chaining

                foreach (var book in books)
                {
                    player1Hand.RemoveAll (card => card.Value == book.Key);
                    player1Books++;
                }  
                
                Value asked2 = player2Hand[0].Value;
                var matches2 = player1Hand.FindAll(card => card.Value == asked2);

                if (matches2.Count > 0)
                {
                    player2Hand.AddRange(matches2);
                    player1Hand.RemoveAll(card => card.Value == asked2);
                }
                else
                {
                    player2Hand.Add(deck.DealOne());
                }

                var books2 = player2Hand.GroupBy(card => card.Value)
                    .Where(group => group.Count() == 4)
                    .ToList(); //dots represent method chaining

                foreach (var book in books2)
                {
                    player2Hand.RemoveAll (card => card.Value == book.Key);
                    player2Books++;
                }  

            }
            if (player1Books > player2Books)
            {
              Console.WriteLine("Player 1 Wins!");  
            }
            
            else if (player2Books > player1Books)
            {
                Console.WriteLine("Player 2 Wins!");
            }

            else 
            {
                Console.WriteLine("It's a tie!");
            }

        }
    }

}