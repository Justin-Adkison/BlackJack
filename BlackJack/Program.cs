namespace BlackJack;

class Program
{
    static void Main(string[] args)
    {
        bool play = false;
        List<string> fourDeckOfCards = new List<string>(208);
        List<string> playersHand = new List<string>();
        List<string> dealersHand = new List<string>();



        Game game = new Game(play);
        Hand hand = new Hand(dealersHand, playersHand);
        game.GetStarted();
        Cards deck = new Cards(fourDeckOfCards);
        deck.CreateDeckOfCards();
        deck.Shuffle(fourDeckOfCards);
        hand.DealCards(fourDeckOfCards);
        Console.WriteLine(hand.CalculatePoints(dealersHand, playersHand));
        //calculate points each player has
        //determine if bust
        //if bust, lose money
        //users decision to hit or stay
        //if hit
        //dowhile loop until user busts or selects to stay
        //////draw another card
        //////recalculate total
        //////determine bust and reiterate through loop
        //ask player if they want to play another hand

        Console.ReadLine();



        // //display cards to console in the order they would be dealt
        // int[] dealtCardsArray = [dealerCard1, playerCard1, playerCard2, dealerCard2];
        // int[] dealtCardsValue = new int[4];
        // string[] dealtCardsFace = new string[4];
        // Console.Clear();

        // //add card values to total points
        // if (i == 0 || i == 3)
        // {
        //     dealerTotal += dealtCardsValue[i];
        // }
        // else
        // {
        //     playerTotal += dealtCardsValue[i];
        // }
        // Console.WriteLine("");
        // Thread.Sleep(2000);

        // Console.Clear();

        // //Displays dealer and player cards and points to console
        // string dealerDisplayMessage = $"Dealer's Cards: {dealtCardsFace[0]}, {dealtCardsFace[3]}";
        // int textLength = dealerDisplayMessage.Length;
        // int horizontalPosition = (Console.WindowWidth - textLength) / 2;
        // Console.SetCursorPosition(horizontalPosition, Console.CursorTop);
        // Console.WriteLine($"{dealerDisplayMessage}");

        // dealerDisplayMessage = $"Dealer Total: {dealerTotal}\n\n";
        // textLength = dealerDisplayMessage.Length;
        // horizontalPosition = (Console.WindowWidth - textLength) / 2;
        // Console.SetCursorPosition(horizontalPosition, Console.CursorTop);
        // Console.WriteLine(dealerDisplayMessage);

        // string playerDisplayMessage = $"Player's Cards: {dealtCardsFace[1]}, {dealtCardsFace[2]}";
        // textLength = playerDisplayMessage.Length;
        // horizontalPosition = (Console.WindowWidth - textLength) / 2;
        // Console.SetCursorPosition(horizontalPosition, Console.CursorTop);
        // Console.WriteLine($"{playerDisplayMessage}");

        // playerDisplayMessage = $"Dealer Total: {playerTotal}\n\n";
        // textLength = playerDisplayMessage.Length;
        // horizontalPosition = (Console.WindowWidth - textLength) / 2;
        // Console.SetCursorPosition(horizontalPosition, Console.CursorTop);
        // Console.WriteLine(playerDisplayMessage);

        // //hit or stay option
        // string? correctedReadResult = "";
        // int newCard = 0;
        // do
        // {
        //     Console.WriteLine("Woudld you like to hit or stay?");
        //     readResult = Console.ReadLine();
        //     correctedReadResult = readResult.ToLower().Trim();

        //     if (correctedReadResult is not null && correctedReadResult == "hit")
        //     {

        //     }
        // } while (correctedReadResult == "hit");
    }
}

class Cards
{
    public List<string> FourDeckOfCards { get; }

    public Cards(List<string> fourDeckOfCards)
    {
        FourDeckOfCards = fourDeckOfCards;
    }

    public List<string> CreateDeckOfCards()
    {
        int index = 0;
        string currentCard = "";
        //4 decks of cards
        for (int h = 0; h < 4; h++)
        {
            //4 different suits
            for (int i = 0; i < 4; i++)
            {
                //13 different cards
                for (int j = 0; j < 13; j++)
                {
                    switch (j)
                    {
                        case 0:
                            currentCard = "A";
                            break;
                        case 10:
                            currentCard = "J";
                            break;
                        case 11:
                            currentCard = "Q";
                            break;
                        case 12:
                            currentCard = "K";
                            break;
                        default:
                            currentCard = (j + 1).ToString();
                            break;

                    }
                    switch (i)
                    {
                        case 0:
                            currentCard += "S";
                            break;
                        case 1:
                            currentCard += "C";
                            break;
                        case 2:
                            currentCard += "H";
                            break;
                        case 3:
                            currentCard += "D";
                            break;
                        default:
                            break;
                    }
                    FourDeckOfCards.Add(currentCard);
                    index++;
                }
            }
        }
        return FourDeckOfCards;
    }

    public List<string> Shuffle(List<string> list)
    {
        Random random = new Random();
        for (int i = list.Count - 1; i > 0; i--)
        {
            //select random index
            int j = random.Next(0, i + 1);
            string temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }

}

class Hand
{
    public static List<string> DealersHand { get; set; }
    public static List<string> PlayersHand { get; set; }

    public Hand(List<string> dealersHand, List<string> playersHand)
    {
        DealersHand = dealersHand;
        PlayersHand = playersHand;
    }
    public void DealCards(List<string> deckOfCards)
    {
        int i = 0;

        DealersHand.Add(deckOfCards[0]);
        deckOfCards.RemoveAt(0);
        Console.WriteLine($"Dealer's card: {DealersHand[0]}");
        Thread.Sleep(2500);

        PlayersHand.Add(deckOfCards[0]);
        deckOfCards.RemoveAt(0);
        Console.WriteLine($"Player's card: {PlayersHand[0]}");
        Thread.Sleep(2500);
        i++;

        PlayersHand.Add(deckOfCards[0]);
        deckOfCards.RemoveAt(0);
        Console.WriteLine($"Player's card: {PlayersHand[1]}");
        Thread.Sleep(2500);


        DealersHand.Add(deckOfCards[0]);
        deckOfCards.RemoveAt(0);
        Console.WriteLine($"Dealer's card: {DealersHand[1]}");
        Thread.Sleep(2500);
    }

    public int CalculatePoints(List<string> DealersHand, List<string> PlayersHand)
    {
        int parse;
        int dealerTotal = 0;
        int playerTotal = 0;
        bool containsAce = false;
        foreach (string card in DealersHand)
        {
            if (int.TryParse(card.Remove(1, 1), out parse))
            {
                dealerTotal += parse;
            }
            else if (card.StartsWith('A'))
            {
                dealerTotal += 11;
                containsAce = true;
            }
            else
            {
                dealerTotal += 10;
            }
        }
        if (dealerTotal > 21 && containsAce == true)
        {
            dealerTotal -= 10;
        }

        foreach (string card in PlayersHand)
        {
            if (int.TryParse(card.Remove(1, 1), out parse))
            {
                playerTotal += parse;
            }
            else if (card.StartsWith('A'))
            {
                playerTotal += 11;
                containsAce = true;
            }
            else
            {
                playerTotal += 10;
            }
        }
        if (playerTotal > 21 && containsAce == true)
        {
            playerTotal -= 10;
        }
        return playerTotal & dealerTotal;
    }
}

class Game
{
    public int DealtCard { get; }
    string? ReadResult = "";

    static bool Play;

    public Game(bool play)
    {
        Play = play;
    }

    public void GetStarted()
    {
        Console.WriteLine("Would you like to try your luck?\nType \"yes\" or \"exit\" followed by the Enter key.");
        ReadResult = Console.ReadLine();
        if (ReadResult is not null)
        {
            ReadResult = ReadResult.ToLower().Trim();
            if (ReadResult == "yes")
                Play = true;
            else
                Environment.Exit(0);
        }
    }
}
class Money
{

}
