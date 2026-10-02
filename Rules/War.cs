namespace Toolkit.Rules.War;

public static class WarRules
{
    extension(Deck deck) //Deck deck? - extension allows PlayWar from deck (doing something with a deck)
        //extension: behaviors -> verbs that someone does /with/ the object
    //don't need this method if not currently playing the game (what extension does)
    //behaviors - a deck can (possibility/behavior) be shuffled vs. how does one shuffle (strategy)
    {
        /// <summary>
        /// play a game of war
        /// <param name="random">Inject your RNG here!</param>
        /// </summary>
        public void PlayWar(Random random)
        {
            deck.Shuffle(random, ShuffleAlgorithms.Default);
            Deck player1 = deck;
            Deck player2 = deck.Split (); //Deck is a data type

        }
       
    }
}