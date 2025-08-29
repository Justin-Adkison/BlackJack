class Hand
{

    public static List<string> DealersHand { get; private set; } = new List<string>();
    public static List<string> PlayersHand { get; private set; } = new List<string>();

    public Hand(List<string> dealersHand, List<string> playersHand)
    {
        DealersHand = dealersHand;
        PlayersHand = playersHand;
    }
    public static void DealInitialCards(List<string> deckOfCards)
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
    }

    public static string DealOneCard(List<string> deckOfCards)
    {
        string temp = deckOfCards[0];
        deckOfCards.RemoveAt(0);
        return temp;
    }

    public static int CalculatePoints(List<string> Hand)
    {
        int parse;
        int total = 0;
        bool containsAce = false;
        foreach (string card in Hand)
        {
            if (card.Substring(0, 2) == "10")
            {
                total += 10;
            }
            else if (int.TryParse(card.Substring(0, 1), out parse))
            {
                total += parse;
            }
            else if (card.StartsWith('A'))
            {
                total += 11;
                containsAce = true;
            }
            else
            {
                total += 10;
            }
        }
        if (total > 21 && containsAce == true)
        {
            total -= 10;
        }
        return total;
    }
}