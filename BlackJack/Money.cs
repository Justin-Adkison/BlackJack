class Money
{
    public decimal Balance { get; private set; } = 1000;

    public decimal Bet { get; set; }
    string? readResult;
    bool validBet = false;
    bool tryParse;
    decimal parse;
     public decimal Winnings { get; private set; }

    public void DisplayBalance()
    {
        Console.WriteLine($"Current balance: {Balance:C}");
    }

    public void WagerAmount()
    {
        validBet = false;
        do
        {
            Console.WriteLine("How much would you like to wager?");
            readResult = Console.ReadLine();
            if (readResult is not null)
            {
                tryParse = decimal.TryParse(readResult, out parse);
                if (tryParse)
                {
                    Bet = parse;
                    if (Bet > Balance)
                    {
                        Console.WriteLine("Insufficient funds. Choose another amount to wager.");
                        continue;
                    }
                    else
                    {
                        validBet = true;
                        Balance -= Bet;
                    }
                }
            }
        } while (!validBet);
    }

    public void Winner()
    {
        Winnings = Bet * 2;
        Balance += Winnings;
    }

    public void BlackJack()
    {
        Winnings = Bet * 2.5m;
        Balance += Winnings;
    }

    public void Push()
    {
        Balance += Bet;
    }

}