namespace BlackJack;

class Program
{
    static void Main(string[] args)
    {
        Random deal = new Random();

        int playerCard1 = deal.Next(1, 14);
        int playerCard2 = deal.Next(1, 14);
        int playerTotal = 0;

        int dealerCard1 = deal.Next(1, 14);
        int dealerCard2 = deal.Next(1, 14);
        int dealerTotal = 0;

        int cardValue = 0;
        string cardFace = "";

        //display cards to console in the order they would be dealt
        int[] dealtCardsArray = [dealerCard1, playerCard1, playerCard2, dealerCard2];
        int[] dealtCardsValue = new int[4];
        string[] dealtCardsFace = new string[4];
        Console.Clear();
        for (int i = 0; i < dealtCardsArray.Length; i++)
        {
            switch (i)
            {
                case 0:
                    Console.Write("Dealer's 1st card: ");
                    break;
                case 1:
                    Console.Write("Player's 1st card: ");
                    break;
                case 2:
                    Console.Write("Player's 2nd card: ");
                    break;
                case 3:
                    Console.Write("Dealer's 2nd card: ");
                    break;

            }

            switch (dealtCardsArray[i])
            {
                case 1:
                    dealtCardsFace[i] = "A";
                    dealtCardsValue[i] = dealtCardsArray[i];
                    Console.WriteLine(dealtCardsFace[i]);
                    break;
                case 11:
                    dealtCardsFace[i] = "J";
                    dealtCardsValue[i] = 10;
                    Console.WriteLine(dealtCardsFace[i]);
                    break;
                case 12:
                    dealtCardsFace[i] = "Q";
                    dealtCardsValue[i] = 10;
                    Console.WriteLine(dealtCardsFace[i]);
                    break;
                case 13:
                    dealtCardsFace[i] = "K";
                    dealtCardsValue[i] = 10;
                    Console.WriteLine(dealtCardsFace[i]);
                    break;
                default:
                    dealtCardsFace[i] = Convert.ToString(dealtCardsArray[i]);
                    dealtCardsValue[i] = dealtCardsArray[i];
                    Console.WriteLine(dealtCardsFace[i]);
                    break;
            }
            Console.WriteLine("");
            Thread.Sleep(2000);
        }
        Console.Clear();

        string dealerDisplayMessage = $"Dealer's Cards: {dealtCardsFace[0]}, {dealtCardsFace[3]}";
        int textLength = dealerDisplayMessage.Length;
        int horizontalPosition = (Console.WindowWidth - textLength) / 2;
        Console.SetCursorPosition(horizontalPosition, Console.CursorTop);
        Console.Write($"{dealerDisplayMessage}\n\n");

        string playerDisplayMessage = $"Player's Cards: {dealtCardsFace[1]}, {dealtCardsFace[2]}";
        textLength = playerDisplayMessage.Length;
        horizontalPosition = (Console.WindowWidth - textLength) / 2;
        Console.SetCursorPosition(horizontalPosition, Console.CursorTop);
        Console.WriteLine(playerDisplayMessage);

    }
}

class Cards
{
    private int dealtCard;

    public int DealtCard { get; }

    public Cards(int dealtCard)
    {
        DealtCard = dealtCard;
    }

    public static void DealCards()
    {
        //deal cards to player and dealer

    }
}

class Money
{

}
