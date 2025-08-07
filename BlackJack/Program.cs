namespace BlackJack;

class Program
{
    static void Main(string[] args)
    {
        bool play = false;
        string[] fourDeckOfCards = new string[208];


        Game game = new Game(play);
        game.GetStarted();
        Cards deck = new Cards(fourDeckOfCards);
        deck.CreateDeckOfCards();
        deck.Shuffle(fourDeckOfCards);
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
    public string[] FourDeckOfCards { get; }

    public Cards(string[] fourDeckOfCards)
    {
        FourDeckOfCards = fourDeckOfCards;
    }

    public string[] CreateDeckOfCards()
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
                            currentCard =
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
                    FourDeckOfCards[index] = currentCard;
                    index++;
                }
            }
        }
        return FourDeckOfCards;
    }

    public string[] Shuffle(string[] array)
    {
        Random random = new Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            //select random index
            int j = random.Next(0, i + 1);
            string temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        return array;
        
    }
}

class Hand
{
    string[] DealersHand { get; set; }
    string[] PlayersHand { get; set; }
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

    public static void DealCards()
    {
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
    }

}
class Money
{

}
