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
    //asks player for wager amount. The amount will then be removed from the balance.
    //logic included to ensure sufficient funds exist.
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
    //player wins amount equal to their bet
    public void Winner()
    {
        Winnings = Bet * 2;
        Balance += Winnings;
    }
    //blackjack has an increased payout
    public void BlackJack()
    {
        Winnings = Bet * 2.5m;
        Balance += Winnings;
    }
    //player recieves their wager back on push
    public void Push()
    {
        Balance += Bet;
    }

}