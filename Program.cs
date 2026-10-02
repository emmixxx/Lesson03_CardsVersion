using Toolkit;
using Toolkit.Rules;
using Toolkit.Rules.GoFish;
using Toolkit.Rules.War;




static void Show(string label, Deck deck)
{
    var cards = deck.Deal(deck.Count);
    Console.WriteLine($"{label} ({cards.Count}):  {string.Join(" ", cards)}");
    deck.AddCardsonTop(cards);
}

var random = new Random(42);          // a fixed seed, so every run matches
var myDeck = Deck.CreateStandardDeck();

Show("before", myDeck);
myDeck.Shuffle(random, ShuffleAlgorithms.Riffle);
Show("after ", myDeck);

// myDeck.PlayWar(random);






myDeck.Shuffle(random, ShuffleAlgorithms.Riffle); //Default - Method with a Noun name
//different shufflealgorithms for different ppl

var warDeck = Deck.CreateStandardDeck();
warDeck.Shuffle(random, ShuffleAlgorithms.Default);
//warDeck.PlayWar(random);


var goFishDeck = Deck.CreateStandardDeck();
var TopCard = goFishDeck.TopCard;
Console.WriteLine(TopCard);
goFishDeck.Shuffle(random, ShuffleAlgorithms.Default);
//goFishDeck.PlayGoFish(random);





//Behaviors: Verbs that an object /can do/ OR /have done to/ it