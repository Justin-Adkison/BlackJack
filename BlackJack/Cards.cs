class Cards
{
    public static List<string> FourDeckOfCards { get; private set; } = new List<string>(208);
    //creates 4 decks of cards
    public static void CreateCards()
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
    }
    //shuffle all four decks of cards
    public static void Shuffle()
    {
        Random random = new Random();
        for (int i = FourDeckOfCards.Count - 1; i > 0; i--)
        {
            //select random index
            int j = random.Next(0, i + 1);
            string temp = FourDeckOfCards[i];
            FourDeckOfCards[i] = FourDeckOfCards[j];
            FourDeckOfCards[j] = temp;
        }
    }
}