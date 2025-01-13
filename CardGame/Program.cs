var round = 0;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("\nPlease Select the Number of Players");
var totalPlayer = Console.ReadLine();
var playerName = "";
string existingCard = "";
for (int i = 1; i <= Convert.ToInt32(totalPlayer); i++)
{
    Console.WriteLine("Enter the Name of Player " + i);
    string userName = Console.ReadLine();
    playerName += userName + ",";
}
playerName = playerName.Remove(playerName.Length - 1);
while (true)
{
    if (round != 0)
    {
        Console.WriteLine("Press a Key to start next round.");
        Console.ReadKey();
    }
    round = 1;
    for (int i = 0; i < Convert.ToInt32(totalPlayer); i++)
    {
        string[] cardValues = { "A♣", "2♣", "3♣", "4♣", "5♣", "6♣", "7♣", "8♣", "9♣", "10♣", "J♣", "Q♣", "K♣",
                                "A♠", "2♠", "3♠", "4♠", "5♠", "6♠", "7♠", "8♠", "9♠", "10♠", "J♠", "Q♠", "K♠" ,
                                "A♥", "2♥", "3♥", "4♥", "5♥", "6♥", "7♥", "8♥", "9♥", "10♥", "J♥", "Q♥", "K♥" ,
                                "A♦", "2♦", "3♦", "4♦", "5♦", "6♦", "7♦", "8♦", "9♦", "10♦", "J♦", "Q♦", "K♦" };
        Random rand = new Random();
        int randomValueIndex = rand.Next(cardValues.Length);
        string card1Value = cardValues[randomValueIndex];
        existingCard = existingCard + "," + card1Value;
        string card2Value;
        do
        {
            int randomValueIndex2 = rand.Next(cardValues.Length);
            card2Value = cardValues[randomValueIndex2];
        }
        while (card2Value == card1Value);
        existingCard = existingCard + "," + card2Value;
        var currentPlayer = playerName.Split(',')[i];
        Console.WriteLine("------------------------------------");
        Console.WriteLine(currentPlayer + "'s Card");
        Console.Write("Card1 -> ");
        if (card1Value.Contains("♥") || card1Value.Contains("♦"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Black;

        }
        Console.WriteLine(card1Value);
        Console.ResetColor();

        Console.Write("Card2 -> ");
        if (card2Value.Contains("♥") || card2Value.Contains("♦"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Black;

        }
        Console.WriteLine(card2Value + "\n");
        Console.ResetColor();

    }
    for (int i = 0; i < Convert.ToInt32(totalPlayer); i++)
    {
        var currentPlayer = playerName.Split(',')[i];
        Console.WriteLine("Do you want to bet " + currentPlayer + "? (y/n)");
        ConsoleKeyInfo cki = Console.ReadKey();
        if (cki.Key.ToString().ToLower() == "y")
        {
            string[] cardValues = { "A♣", "2♣", "3♣", "4♣", "5♣", "6♣", "7♣", "8♣", "9♣", "10♣", "J♣", "Q♣", "K♣",
                                    "A♠", "2♠", "3♠", "4♠", "5♠", "6♠", "7♠", "8♠", "9♠", "10♠", "J♠", "Q♠", "K♠" ,
                                    "A♥", "2♥", "3♥", "4♥", "5♥", "6♥", "7♥", "8♥", "9♥", "10♥", "J♥", "Q♥", "K♥" ,
                                    "A♦", "2♦", "3♦", "4♦", "5♦", "6♦", "7♦", "8♦", "9♦", "10♦", "J♦", "Q♦", "K♦" };
            Random rand = new Random();
            string card1Value;
            do
            {
                int randomValueIndex = rand.Next(cardValues.Length);
                card1Value = cardValues[randomValueIndex];
            }
            while (existingCard.Split(",").Contains(card1Value));
            existingCard = existingCard + "," + card1Value;

            Console.Write("\n" + currentPlayer + "'s Card -> ");
            if (card1Value.Contains("♥") || card1Value.Contains("♦"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;

            }
            Console.WriteLine(card1Value + "\n");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\n" + currentPlayer + " Skipped\n");
        }
    }
    string[] playerRearranged = playerName.Split(',');
    for (int j = 0; j < 2; j++)
    {
        string[] rearranged = new string[playerRearranged.Length];
        for (int k = 0; k < rearranged.Length; k++)
        {
            rearranged[k] = playerRearranged[(j + k) % playerRearranged.Length];
        }
        playerName = string.Join(",", rearranged);
    }
    Console.ReadLine();
    Console.Clear();

}
