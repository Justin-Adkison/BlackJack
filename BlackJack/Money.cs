using System.Transactions;

class Money
{
    public decimal Balance { get; private set; } = 1000;

    public decimal Bet { get; private set; } = 0;
    public decimal InsuranceWager { get; private set; } = 0;
    public bool HasInsurance { get; private set; } = false;
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
    public void Push() => Balance += Bet;

    public void OfferInsurance()
    {
        Console.WriteLine("Would you like to purchase insurance?\nyes or no?");
        readResult = Console.ReadLine();
        do
        {
            if (readResult is not null)
            {
                readResult.ToLower().Trim();
                if (readResult == "yes")
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
                                InsuranceWager = parse;
                                if (InsuranceWager > Balance)
                                {
                                    Console.WriteLine("Insufficient funds. Choose another amount to wager.");
                                    continue;
                                }
                                else if (InsuranceWager > (0.5m * Bet))
                                {
                                    Console.WriteLine("The insurance wager must be no greater than half of the original wager amount.");
                                }
                                else
                                {
                                    validBet = true;
                                    Balance -= InsuranceWager;
                                    HasInsurance = true;
                                }
                            }
                        }
                    } while (!validBet);
                }
                else
                    HasInsurance = false;
            }
        } while (readResult is null);
    }

    public void WinInsurance() => Balance += 2 * InsuranceWager;
}