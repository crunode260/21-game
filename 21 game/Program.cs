using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace _21_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //READ THIS:
            /*This program was created when I only knew the very basics of code.
              This means it is not the best and I have created methods etc. in Main() instead of outside it.
              It was just created as a fun little project and it works fine (to the best of my knowledge) but it is nowhere near a 'good' program
              Thank you, 
                - Crunode260.
            */
            
            void killer21()
            {

                void gameAgainstBot()
                {

                    string tempMaxNumber = "0";
                    int maxNumber = 0;
                    string rules = "";
                    int botMaxNumber = 0;
                    int amountMoreThanBotMaxNumber = 1;

                    //Loop to input numbers
                    int playerTurn(int botMaxNumber)
                    {
                        amountMoreThanBotMaxNumber = 1;
                        Thread.Sleep(300);
                        Console.WriteLine("Your turn");
                        do
                        {

                            //Checking if the number entered is valid
                            tempMaxNumber = Console.ReadLine().ToUpper();
                            while ((tempMaxNumber != Convert.ToString(botMaxNumber + amountMoreThanBotMaxNumber) && tempMaxNumber != "END") || ((amountMoreThanBotMaxNumber <= 1 || amountMoreThanBotMaxNumber > 3) && tempMaxNumber == "END"))
                            {
                                Console.WriteLine("Invalid entry - please re-enter the data intended");
                                tempMaxNumber = Console.ReadLine().ToUpper();
                            }
                            if (tempMaxNumber != "END")
                            {
                                maxNumber = Convert.ToInt32(tempMaxNumber);
                                amountMoreThanBotMaxNumber++;
                            }
                        }
                        while (tempMaxNumber != "END" && maxNumber < botMaxNumber + 3 && maxNumber != 21);
                        if (maxNumber == 20)
                        {
                            Console.WriteLine("Cheater!");
                        }
                        return maxNumber;
                    }

                    //Loop for bots go
                    int botTurn(int maxNumber)
                    {
                        Thread.Sleep(300);
                        Console.WriteLine("Bot's turn");
                        botMaxNumber = maxNumber;
                        do
                        {
                            botMaxNumber = botMaxNumber + 1;
                            Thread.Sleep(500);
                            Console.WriteLine(botMaxNumber);
                        }
                        while (botMaxNumber % 4 != 0);
                        return botMaxNumber;
                    }

                    Console.WriteLine("Welcome to your game against the bot!");

                    //Validating that rules is a valid input
                    while (rules != "yes" && rules != "no")
                    {

                        //Asking if the user wants to view the rules of the game
                        Console.WriteLine("Would you like to view the rules of the game?");
                        rules = Console.ReadLine().ToLower();
                    }
                    if (rules == "yes")
                    {

                        //Telling the player the rules
                        Console.WriteLine("The rules of the game are: ");
                        Console.WriteLine("");
                        Thread.Sleep(950);
                        Console.WriteLine("You must say up to three consecutive integers on each of your turns, starting from 1 on your first turn");
                        Console.WriteLine("");
                        Thread.Sleep(1500);
                        Console.WriteLine("Enter each number on a new row, then type 'END' on a new row when you have entered all the numbers you wish to enter (You don't need to do this if you did all three possible numbers)");
                        Console.WriteLine("");
                        Thread.Sleep(3000);
                        Console.WriteLine("This/these integer(s) must follow on from the previous number from the bot");
                        Console.WriteLine("");
                        Thread.Sleep(1500);
                        Console.WriteLine("The person who says the number 21 loses");
                        Console.WriteLine("");
                        Thread.Sleep(1500);
                    }
                    Console.WriteLine("Good luck!");
                    Console.WriteLine("");
                    Thread.Sleep(500);
                    Console.WriteLine("You go first!");
                    Console.WriteLine("");
                    Thread.Sleep(500);
                    Console.WriteLine("Enter your number(s)");

                    maxNumber = playerTurn(botMaxNumber);

                    //Calling functions
                    while (maxNumber != 21)
                    {
                        botMaxNumber = botTurn(maxNumber);
                        maxNumber = playerTurn(botMaxNumber);
                    }
                    Console.WriteLine("You lose!");
                }

                void gameAgainstPlayer()
                {
                    string tempMaxNumber = "0";
                    int player1MaxNumber = 0;
                    string rules = "";
                    int player2MaxNumber = 0;
                    int amountMoreThanLastMaxNumber = 1;

                    //Loop to input numbers
                    int player1Turn(int player2MaxNumber)
                    {
                        amountMoreThanLastMaxNumber = 1;
                        Console.WriteLine("Player 1's turn");
                        do
                        {

                            //Checking if the number entered is valid
                            tempMaxNumber = Console.ReadLine().ToUpper();
                            while ((tempMaxNumber != Convert.ToString(player2MaxNumber + amountMoreThanLastMaxNumber) && tempMaxNumber != "END") || ((amountMoreThanLastMaxNumber <= 1 || amountMoreThanLastMaxNumber > 3) && tempMaxNumber == "END"))
                            {
                                Console.WriteLine("Invalid entry - please re-enter the data intended");
                                tempMaxNumber = Console.ReadLine().ToUpper();
                            }
                            if (tempMaxNumber != "END")
                            {
                                player1MaxNumber = Convert.ToInt32(tempMaxNumber);
                                amountMoreThanLastMaxNumber++;
                            }
                        }
                        while (tempMaxNumber != "END" && player1MaxNumber < player2MaxNumber + 3 && player1MaxNumber != 21);
                        return player1MaxNumber;
                    }
                    int player2Turn(int player1MaxNumber)
                    {
                        amountMoreThanLastMaxNumber = 1;
                        Console.WriteLine("Player 2's turn");
                        do
                        {

                            //Checking if the number entered is valid
                            tempMaxNumber = Console.ReadLine().ToUpper();
                            while ((tempMaxNumber != Convert.ToString(player1MaxNumber + amountMoreThanLastMaxNumber) && tempMaxNumber != "END") || ((amountMoreThanLastMaxNumber <= 1 || amountMoreThanLastMaxNumber > 3) && tempMaxNumber == "END"))
                            {
                                Console.WriteLine("Invalid entry - please re-enter the data intended");
                                tempMaxNumber = Console.ReadLine().ToUpper();
                            }
                            if (tempMaxNumber != "END")
                            {
                                player2MaxNumber = Convert.ToInt32(tempMaxNumber);
                                amountMoreThanLastMaxNumber++;
                            }
                        }
                        while (tempMaxNumber != "END" && player2MaxNumber < player1MaxNumber + 3 && player2MaxNumber != 21);
                        return player2MaxNumber;
                    }

                    Console.WriteLine("Welcome to your two player game");

                    //Validating that rules is a valid input
                    while (rules != "yes" && rules != "no")
                    {

                        //Asking if the user wants to view the rules of the game
                        Console.WriteLine("Would you like to view the rules of the game?");
                        rules = Console.ReadLine().ToLower();
                    }
                    if (rules == "yes")
                    {

                        //Telling the player the rules
                        Console.WriteLine("The rules of the game are: ");
                        Console.WriteLine("");
                        Thread.Sleep(950);
                        Console.WriteLine("Each player must say up to three consecutive integers on each of their turns, starting from 1 on the first turn");
                        Console.WriteLine("");
                        Thread.Sleep(1500);
                        Console.WriteLine("Enter each number on a new row, then type 'END' on a new row when you have entered all the numbers you wish to enter (You don't need to do this if you did all three possible numbers)");
                        Console.WriteLine("");
                        Thread.Sleep(3000);
                        Console.WriteLine("This/these integer(s) must follow on from the previous number from the other player");
                        Console.WriteLine("");
                        Thread.Sleep(1500);
                        Console.WriteLine("The person who says the number 21 loses");
                        Console.WriteLine("");
                        Thread.Sleep(1500);
                    }
                    Console.WriteLine("Good luck to both players!");
                    Console.WriteLine("");
                    Thread.Sleep(500);
                    Console.WriteLine("Player 1 may now take their first turn!");
                    Console.WriteLine("");
                    Thread.Sleep(500);
                    Console.WriteLine("Enter your number(s)");

                    player1MaxNumber = player1Turn(player2MaxNumber);

                    //Looping if neither player has said 21
                    while (player1MaxNumber != 21 && player2MaxNumber != 21)
                    {
                        player2MaxNumber = player2Turn(player1MaxNumber);
                        if (player2MaxNumber != 21)
                        {
                            player1MaxNumber = player1Turn(player2MaxNumber);
                        }

                    }
                    
                    //Ending game if a player has won
                    if (player1MaxNumber == 21)
                    {
                        Console.WriteLine("Player 2 wins!");
                    }
                    else
                    {
                        Console.WriteLine("Player 1 wins!");
                    }
                }


                //Introduction to the game
                Console.WriteLine("Welcome to Killer 21!");
                Console.WriteLine("");
                Thread.Sleep(500);
                Console.WriteLine("Would you like to play against a bot (enter 'bot') or a real player (enter 'player')?");
                string game = Console.ReadLine().ToLower();
                
                //Validating input
                while (game != "bot" && game != "player")
                {
                    Console.WriteLine("Invalid input, please try again");
                    game = Console.ReadLine().ToLower();
                }
                if (game == "bot")
                {
                    gameAgainstBot();
                }
                else
                {
                    gameAgainstPlayer();
                }
                Console.WriteLine("Thanks for playing!");
            }

            killer21();

        }
             
    }
}