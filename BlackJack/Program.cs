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

        //display cards to console in the order they would be dealt
        int[] dealtCardsArray = [dealerCard1, playerCard1, playerCard2, dealerCard2];
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
                    Console.WriteLine("A");
                    break;
                case 11:
                    Console.WriteLine("J");
                    break;
                case 12:
                    Console.WriteLine("Q");
                    break;
                case 13:
                    Console.WriteLine("K");
                    break;
                default:
                    Console.WriteLine(dealtCardsArray[i]);
                    break;
            }
            Thread.Sleep(1000);
        }

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
