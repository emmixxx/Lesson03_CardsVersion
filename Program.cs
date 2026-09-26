using Toolkit;
using Toolkit.Rules.GoFish;
using Toolkit.Rules.War;



var random = new Random();


var warDeck = Deck.CreateStandardDeck();
warDeck.Shuffle(random);
warDeck.PlayWar(random);


var goFishDeck = Deck.CreateStandardDeck();
var TopCard = goFishDeck.TopCard;
Console.WriteLine(TopCard);
goFishDeck.Shuffle(random);
goFishDeck.PlayGoFish(random);





//Behaviors: Verbs that an object /can do/ OR /have done to/ it