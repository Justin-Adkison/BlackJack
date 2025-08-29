class Game
{
    public int DealtCard { get; }
    static string? ReadResult = "";

    static bool play;


    public static bool GetStarted()
    {
        Console.WriteLine("Would you like to try your luck?\nType \"yes\" or \"exit\" followed by the Enter key.");
        ReadResult = Console.ReadLine();
        if (ReadResult is not null)
        {
            ReadResult = ReadResult.ToLower().Trim();
            if (ReadResult == "yes")
            {
                play = true;
                Cards.CreateCards();
                Cards.Shuffle();
            }
            else
                play = false;
        }
        return play;
    }


    public static bool PlayAnotherHand()
    {
        Console.WriteLine("Would you like to play another hand?\nType \"yes\" or \"no\" followed by the Enter key.");
        ReadResult = Console.ReadLine();
        if (ReadResult is not null)
        {
            ReadResult = ReadResult.ToLower().Trim();
            if (ReadResult == "yes")
            {
                play = true;
                Hand.DealersHand.Clear();
                Hand.PlayersHand.Clear();
            }
            else
                play = false;
        }
        return play;
    }
    public static bool Hit()
    {
        bool hit = false;
        bool validEntry = false;
        do
        {
            Console.WriteLine("Hit or Stand?");
            ReadResult = Console.ReadLine();
            if (ReadResult is not null)
            {
                ReadResult.ToLower().Trim();
                if (ReadResult == "hit")
                {
                    hit = true;
                    validEntry = true;
                }
                else if (ReadResult == "stand")
                {
                    validEntry = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid response.");
                    continue;
                }
            }
        } while (validEntry == false);
        return hit;
    }

    public static bool DidBust(int total)
    {
        bool bust;
        if (total > 21)
            bust = true;
        else
            bust = false;
        return bust;
    }

    public static bool DeterminePush(int PlayerTotal, int DealerTotal)
    {
        return PlayerTotal == DealerTotal;
    }

    public static bool DetermineWinner(int PlayerTotal, int DealerTotal, bool DealerBust, bool PlayerBust)
    {
        bool playerWins = false;
        if (PlayerBust)
        {
            playerWins = false;
        }
        else if (DealerBust)
        {
            playerWins = true;
        }
        else if (PlayerTotal > DealerTotal)
        {
            playerWins = true;
        }
        else if (PlayerTotal < DealerTotal)
        {
            playerWins = false;
        }
        return playerWins;
    }
}