using System.Net;

namespace BlackJack;

class Program
{
    static void Main(string[] args)
    {
        var player1 = new Money();
        bool play = false;
        bool hit;
        int dealerTotal;
        int playerTotal;
        bool blackJack;

        Game.GetStarted();
        do
        {
            blackJack = false;
            player1.DisplayBalance();
            player1.WagerAmount();
            Hand.DealInitialCards(Cards.FourDeckOfCards);
            dealerTotal = Hand.CalculatePoints(Hand.DealersHand);
            //if dealer has 21
            //player loses
            //else
            playerTotal = Hand.CalculatePoints(Hand.PlayersHand);
            Console.WriteLine($"Player Total = {playerTotal}");
            if (playerTotal == 21)
            {
                player1.BlackJack();
                Console.WriteLine($"You got 21! Winnings: {player1.Winnings}");
                blackJack = true;
            }

            int i = 2;
            bool playerBust = false;
            bool dealerBust = false;
            if (!blackJack)
            {
                do
                {
                    hit = Game.Hit();
                    if (hit)
                    {
                        Hand.PlayersHand.Add(Hand.DealOneCard(Cards.FourDeckOfCards));
                        playerTotal = Hand.CalculatePoints(Hand.PlayersHand);
                        string dealtCard = Hand.PlayersHand[i];
                        i++;
                        Console.WriteLine($"Player's Card: {dealtCard}");
                        Console.WriteLine($"Player Total = {playerTotal}");
                        Thread.Sleep(2000);

                        if (Game.DidBust(playerTotal))
                        {
                            playerBust = true;
                            Console.WriteLine("Bust!");
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                        break;
                } while (hit);

                if (!playerBust)
                {
                    i = 2;
                    Console.WriteLine($"Dealer's card: {Hand.DealersHand[1]}");
                    dealerTotal = Hand.CalculatePoints(Hand.DealersHand);
                    Console.WriteLine($"Dealer Total: {dealerTotal}");
                    Thread.Sleep(2000);
                    while (dealerTotal < 17 && !dealerBust)
                    {
                        Hand.DealersHand.Add(Hand.DealOneCard(Cards.FourDeckOfCards));
                        dealerTotal = Hand.CalculatePoints(Hand.DealersHand);
                        string dealtCard = Hand.DealersHand[i];
                        i++;
                        Console.WriteLine($"Dealer's Card: {dealtCard}");
                        Console.WriteLine($"Dealer Total = {dealerTotal}");
                        Thread.Sleep(2000);
                        if (Game.DidBust(dealerTotal))
                        {
                            dealerBust = true;
                            break;
                        }
                        else
                            continue;
                    }
                }

                if (Game.DeterminePush(playerTotal, dealerTotal))
                {
                    Console.WriteLine("Push");
                    player1.Push();
                }
                else
                {
                    if (Game.DetermineWinner(playerTotal, dealerTotal, dealerBust, playerBust))
                    {
                        Console.WriteLine($"Congrtulations. You won this hand. Winnings: {player1.Bet:C}");
                        player1.Winner();
                    }
                    else
                    {
                        Console.WriteLine("Better luck next hand.");
                    }

                }
            }
            play = Game.PlayAnotherHand();
        } while (play);

        //ask player if they want to play another hand

        Console.ReadLine();


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

    }
}
