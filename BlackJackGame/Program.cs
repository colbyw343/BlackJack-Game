using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BlackJackGame
{
    class Program
    {
        public static string[] Cards = new string[52];
        public static List<string> playerHand = new List<string>();
        public static List<string> opponentHand = new List<string>();
        public static int roundCount = 0;
        public static int playerCardAmount = 0;
        public static int opponentCardAmount = 0;
        public static int playerWins = 0;
        public static int oppWins = 0;
        public static void CardDeal(string str)
        {
            Thread.Sleep(1000);
            Console.Write(str);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blackjack (also known as 21)!");
            Console.ReadLine();
            //This asks the player how many rounds they want to play, unlike my other card game (go-fish), where the user played until either the cpu or the player
            //had 5 books
            Console.WriteLine("How many rounds would you like to play?");
            Console.Write("3 "); Console.Write("5 "); Console.Write("7 "); Console.Write("or 9");
            string bleh = Console.ReadLine();
            int roundAnswer = int.Parse(bleh);
            //Start by getting the cards for the deck
            Cards[0] = "Ace";
            Cards[1] = "Ace";
            Cards[2] = "Ace";
            Cards[3] = "Ace";
            Cards[4] = "2";
            Cards[5] = "2";
            Cards[6] = "2";
            Cards[7] = "2";
            Cards[8] = "3";
            Cards[9] = "3";
            Cards[10] = "3";
            Cards[11] = "3";
            Cards[12] = "4";
            Cards[13] = "4";
            Cards[14] = "4";
            Cards[15] = "4";
            Cards[16] = "5";
            Cards[17] = "5";
            Cards[18] = "5";
            Cards[19] = "5";
            Cards[20] = "6";
            Cards[21] = "6";
            Cards[22] = "6";
            Cards[23] = "6";
            Cards[24] = "7";
            Cards[25] = "7";
            Cards[26] = "7";
            Cards[27] = "7";
            Cards[28] = "8";
            Cards[29] = "8";
            Cards[30] = "8";
            Cards[31] = "8";
            Cards[32] = "9";
            Cards[33] = "9";
            Cards[34] = "9";
            Cards[35] = "9";
            Cards[36] = "10";
            Cards[37] = "10";
            Cards[38] = "10";
            Cards[39] = "10";
            Cards[40] = "Jack";
            Cards[41] = "Jack";
            Cards[42] = "Jack";
            Cards[43] = "Jack";
            Cards[44] = "Queen";
            Cards[45] = "Queen";
            Cards[46] = "Queen";
            Cards[47] = "Queen";
            Cards[48] = "King";
            Cards[49] = "King";
            Cards[50] = "King";
            Cards[51] = "King";
            DealingPlayerHand();
            DealingOpponentHand();
            //This tells the program to keep running until the amount of rounds have been completed
            while (roundCount < roundAnswer)
            {
                PlayerTurn();
                OpponentTurn();
                ComparingCards();
                if (roundCount == roundAnswer)
                {
                    Console.Clear();
                    Console.WriteLine("That concludes the game!");
                    Console.ReadLine();
                    if (playerWins > oppWins)
                    {
                        Console.WriteLine("You are the winner of Blackjack! Congratulations!");
                        Console.ReadLine();
                        break;
                    }
                    if (playerWins < oppWins)
                    {
                        Console.WriteLine("Bummer! The opponent has beaten you in BlackJack! Better luck next time!");
                        Console.ReadLine();
                        break;
                    }
                }
            }
            //A round is over when the cpu has taken its turn
            return;
        }

        public static void DealingPlayerHand()
        {
            Console.WriteLine("Round" + roundCount);
            Console.WriteLine("Let's deal out your cards");
            Random random = new Random();
            int card1 = random.Next(0, 51);
            string firstCard = Cards[card1];
            int card2 = random.Next(0, 51);
            string secondCard = Cards[card2];
            playerHand.Add(firstCard);
            playerHand.Add(secondCard);
            Console.WriteLine("The cards you have in your hand are:");
            for (int i = 0; i < playerHand.Count; i++)
            {
                CardDeal($"|{playerHand[i]}| ");
            }
            Console.ReadLine();
        }

        public static void DealingOpponentHand()
        {
            Console.WriteLine("The opponent now has cards as well.");
            Random random = new Random();
            int card1 = random.Next(0, 51);
            string firstCard = Cards[card1];
            int card2 = random.Next(0, 51);
            string secondCard = Cards[card2];
            opponentHand.Add(firstCard);
            opponentHand.Add(secondCard);
        }

        public static void PlayerTurn()
        {
            Console.Clear();
            Console.WriteLine("The cards you have are:");
            foreach (string card in playerHand)
            {
                Console.Write($"|{card}| ");
                if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9" || card == "10")
                {
                    int cardValue = int.Parse(card);
                    playerCardAmount += cardValue;
                }
                if (card == "Ace")
                {
                    Console.WriteLine("Would you like your Ace to be 11 or 1?");
                    string response = Console.ReadLine();
                    if (response.ToUpper() == "11")
                    {
                        playerCardAmount += 11;
                    }
                    if (response.ToUpper() == "1")
                    {
                        playerCardAmount += 1;
                    }
                }
                if (card == "Jack" || card == "Queen" || card == "King")
                {
                    playerCardAmount += 10;
                }
            }
            Console.ReadLine();
            Console.WriteLine($"So your total amount right now is {playerCardAmount}.");
            Console.ReadLine();
            PlayerAddingMoreCards();
        }

        public static void OpponentTurn()
        {
            Console.WriteLine("Now it's your opponent's turn!");
            Console.ReadLine();
            foreach (string card in opponentHand)
            {
                if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9" || card == "10")
                {
                    int cardValue = int.Parse(card);
                    opponentCardAmount += cardValue;
                }
                if (card == "Ace")
                {
                    Random random = new Random();
                    int ace = random.Next(0, 1);
                    //Zero amount being that the cpu chose to make the Ace 11, and the 1 amount to make the Ace 1.
                    if (ace == 0)
                    {
                        opponentCardAmount += 11;
                    }
                    if (ace == 1)
                    {
                        opponentCardAmount += 1;
                    }
                }
                if (card == "Jack" || card == "Queen" || card == "King")
                {
                    opponentCardAmount += 10;
                }
            }
            while(opponentCardAmount < 15)
            {
                CpuAddingMoreCards();
                if(opponentCardAmount > 15)
                {
                    break;
                }
            }
            Console.WriteLine("The opponent has ended their turn.");
            Console.ReadLine();

            roundCount++;
        }

        public static void PlayerAddingMoreCards()
        {
            Console.WriteLine("Would you like to add another card?");
            string adding = Console.ReadLine();
            //If the user wants another card
            if (adding.ToUpper() == "YES")
            {
                //It will randomly select one from "the deck"
                Random random = new Random();
                int card1 = random.Next(0, 51);
                string card = Cards[card1];
                playerHand.Add(card);
                Console.WriteLine($"The card you got was {card}");
                Console.ReadLine();
                //This gets the card amounts and adds them all together
                if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" || card == "7" || card == "8" || card == "9" || card == "10")
                {
                    int cardValue = int.Parse(card);
                    playerCardAmount += cardValue;
                }
                if (card == "Ace")
                {
                    Console.WriteLine("Would you like your Ace to be 11 or 1?");
                    string response = Console.ReadLine();
                    if (response.ToUpper() == "11")
                    {
                        playerCardAmount += 11;
                    }
                    if (response.ToUpper() == "1")
                    {
                        playerCardAmount += 1;
                    }
                }
                if (card == "Jack" || card == "Queen" || card == "King")
                {
                    playerCardAmount += 10;
                }
                //This occurs when the player has gone over 21
                if (playerCardAmount > 21)
                {
                    Console.Clear();
                    Console.WriteLine("Uh-oh! You went over 21! Let's see what your opponent has!");
                    Console.ReadLine();
                    return;
                }
                //This tells the player the amount, and restarts the whole "adding cards" process
                Console.WriteLine($"So now the amount that you have is {playerCardAmount}");
                PlayerAddingMoreCards();
                return;
            }
            return;
        }

        public static void CpuAddingMoreCards()
        {
            Random rnd = new Random();
            int card1 = rnd.Next(0, 51);
            string oppCard = Cards[card1];
            opponentHand.Add(oppCard);

            if (oppCard == "2" || oppCard == "3" || oppCard == "4" || oppCard == "5" || oppCard == "6" || oppCard == "7" || oppCard == "8" || oppCard == "9" || oppCard == "10")
            {
                int cardValue = int.Parse(oppCard);
                opponentCardAmount += cardValue;
            }
            if (oppCard == "Ace")
            {
                Random random = new Random();
                int ace = random.Next(0, 1);
                //Zero amount being that the cpu chose to make the Ace 11, and the 1 amount to make the Ace 1.
                if (ace == 0)
                {
                    opponentCardAmount += 11;
                }
                if (ace == 1)
                {
                    opponentCardAmount += 1;
                }
            }
            if (oppCard == "Jack" || oppCard == "Queen" || oppCard == "King")
            {
                opponentCardAmount += 10;
            }

            if (opponentCardAmount == 21)
            {
                return;
            }
            
            if (opponentCardAmount > 15)
            {
                return;
            }
        }


        public static void ComparingCards()
        {
            Console.WriteLine($"The end of round {roundCount}! Let's tally up the cards!");
            Console.ReadLine();
            Console.WriteLine("So the cards that you ended up with are:");
            foreach (string card in playerHand)
            {
                Console.Write("|" + card + "| ");
            }
            Console.ReadLine();
            Console.WriteLine($"And the amount that totals up to is {playerCardAmount}");
            Console.ReadLine();
            Console.WriteLine($"The opponent's cards were:");
            foreach (string card in opponentHand)
            {
                Console.Write("|" + card + "| ");
            }
            Console.ReadLine();
            Console.WriteLine($"And the amount that the opponent has is {opponentCardAmount}");
            //This determines the winner of the round
            //If the player is the only one with 21
            if (playerCardAmount == 21 && opponentCardAmount != 21)
            {
                Console.WriteLine("You won! You had 21! On to the next round!");
                Console.ReadLine();
                playerHand.Clear();
                opponentHand.Clear();
                playerCardAmount = 0;
                opponentCardAmount = 0;
                playerWins++;
                Console.Clear();
                DealingPlayerHand();
                DealingOpponentHand();
                return;
            }
            //If the opponent is the only one with 21
            if (playerCardAmount != 21 && opponentCardAmount == 21)
            {
                Console.WriteLine("Looks like the opponent won this round! On to the next round!");
                Console.ReadLine();
                playerHand.Clear();
                opponentHand.Clear();
                playerCardAmount = 0;
                opponentCardAmount = 0;
                oppWins++;
                Console.Clear();
                DealingPlayerHand();
                DealingOpponentHand();
                return;
            }
            //If both the opponent and the player have 21
            if (playerCardAmount == 21 && opponentCardAmount == 21)
            {
                Console.WriteLine("Unbelievable! It's a tie! No one gets points for this round!");
                Console.ReadLine();
                playerHand.Clear();
                opponentHand.Clear();
                playerCardAmount = 0;
                opponentCardAmount = 0;
                Console.Clear();
                DealingPlayerHand();
                DealingOpponentHand();
                return;
            }
            //If the player went over and the opponent still is under
            if (playerCardAmount > 21 && opponentCardAmount < 21)
            {
                Console.WriteLine("Since you were above 21, and the opponent was not, the opponent wins this round!");
                Console.ReadLine();
                playerHand.Clear();
                opponentHand.Clear();
                playerCardAmount = 0;
                opponentCardAmount = 0;
                oppWins++;
                Console.Clear();
                DealingPlayerHand();
                DealingOpponentHand();
                return;
            }
            //If the player is under but the opponent went over
            if (playerCardAmount < 21 && opponentCardAmount > 21)
            {
                Console.WriteLine("Since the opponent had a total of greater than 21, you win by default! On to the next round!");
                Console.ReadLine();
                playerHand.Clear();
                opponentHand.Clear();
                playerCardAmount = 0;
                opponentCardAmount = 0;
                playerWins++;
                Console.Clear();
                DealingPlayerHand();
                DealingOpponentHand();
                return;
            }
            //If both players are still under, it sees which player was closest to 21
            if (playerCardAmount < 21 && opponentCardAmount < 21)
            {
                for (int i = 21; i > 0; i--)
                {
                    if (i == playerCardAmount)
                    {
                        Console.WriteLine("Looks like you were the closest one to 21! The round goes to you! On to the next round!");
                        Console.ReadLine();
                        playerHand.Clear();
                        opponentHand.Clear();
                        playerCardAmount = 0;
                        opponentCardAmount = 0;
                        playerWins++;
                        Console.Clear();
                        DealingPlayerHand();
                        DealingOpponentHand();
                        return;
                    }
                    if (i == opponentCardAmount)
                    {
                        Console.WriteLine("Looks like the opponent was the closest to 21! The opponent wins this round. On to the next round!");
                        Console.ReadLine();
                        playerHand.Clear();
                        opponentHand.Clear();
                        playerCardAmount = 0;
                        opponentCardAmount = 0;
                        oppWins++;
                        Console.Clear();
                        DealingPlayerHand();
                        DealingOpponentHand();
                        return;
                    }
                }
            }

        }
    }
}
