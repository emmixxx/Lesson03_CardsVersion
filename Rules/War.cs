namespace Toolkit.Rules.War;

public static class WarRules
{
    extension(Deck deck) //Deck deck? - extension allows PlayWar from deck (doing something with a deck)
    //don't need this method if not currently playing the game (what extension does)
    {
        /// <summary>
        /// play a game of war
        /// <param name="random">Inject your RNG here!</param>
        /// </summary>
        public void PlayWar(Random random)
        {
            deck.Shuffle(random);
            Deck player1 = deck;
            Deck player2 = deck.Split (); //Deck is a data type

        }
       
    }
}