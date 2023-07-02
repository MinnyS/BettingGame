using System;

namespace BettingGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Declare and initialize variables.
            Random randomNumberGenerator = new Random(); // Random number generator.
            double odds = 0.5; // Odds of winning bet.
            decimal winMultiplier = 2; // Number by which to multiply the bet amount to calculate the amount won if the bet was won.
            decimal betAmount; // Amount user bets.
            decimal winAmount; // Amount user will receive if they win the bet.
            bool keepPlaying = true; // Whether user wants to keep playing.
            Player player = new Player(ObtainNameOfUser(), ObtainCurrencyOfUser()); // Obtain user's name and currency symbol, then create new Player object.
            decimal startingAmount = ObtainStartingBalanceOfUser(); // Obtain user's starting balance.

            // Set player's current balance.
            player.SetCurrentBalance(startingAmount); // Set Player object's current balance to the starting balance.
            Console.WriteLine($"You are starting the game with {player.ReturnFormattedAmount(startingAmount)}."); // Notify user how much they're starting the game with.

            // Continue betting while player has money.
            while (player.CurrentBalance > 0 && keepPlaying)
            {
                // Display game information to user.
                Console.WriteLine(); // Add a blank line.
                Console.WriteLine($"You have {player.CurrentBalanceAsString()}."); // Display player's current balance.
                Console.WriteLine($"If you win, you'll get {winMultiplier} times the amount you bet!"); // Display win multiplier.
                Console.WriteLine($"The odds of winning the bet are {odds}."); // Display odds of winning.

                // Obtain user's bet.
                Console.Write("Enter the amount you would like to bet: "); // Prompt
                decimal.TryParse(Console.ReadLine(), out betAmount); // Obtain the amount of user's bet.

                // If user tried to bet more money than they have, notify them.
                if (betAmount > player.CurrentBalance)
                {
                    Console.WriteLine("You cannot bet more money than you currently have."); // Notify user.
                }
                else if(betAmount == 0) // If user tried to bet nothing
                {
                    Console.WriteLine($"You must bet more than {player.CurrencySymbol}0"); // Notify user.
                }
                else // If user's bet was a valid amount to bet
                {
                    // Place the bet.
                    Console.WriteLine($"You bet {player.ReturnFormattedAmount(betAmount)}"); // Notify user how much they bet.
                    player.Withdraw(betAmount); // Withdraw amount user is betting from their account balance.

                    // If user won the bet, notify them and deposit their award money to their account.
                    if (randomNumberGenerator.NextDouble() <= odds)
                    {
                        winAmount = betAmount * winMultiplier; // Calculate the amount the player receives for winning.
                        Console.WriteLine($"Congratulations, {player.Name}!  You won the bet.  {player.ReturnFormattedAmount(winAmount)} will be deposited to your account."); // Notify user.
                        player.Deposit(winAmount); // Deposit amount player receives for winnig.
                    }
                    else // If user lost the bet, notify them.
                    {
                        Console.WriteLine($"Oh no, {player.Name}!  You didn't win.  You lost {player.ReturnFormattedAmount(betAmount)}.  Better luck next time!");
                    }
                }

                // If player has money
                if(player.CurrentBalance > 0)
                {
                    // See if user would like to keep betting.
                    Console.Write($"Now you have {player.CurrentBalanceAsString()}.  Would you like to keep betting?  If so, enter anything except \"N\". "); // Prompt
                    if (Console.ReadLine() == "N") // If user would not like to keep betting
                    {
                        keepPlaying = false; // Set variable to value to end betting.
                    }
                }
                else // if player does not have money
                {
                    Console.WriteLine("Uh-oh!  You're out of money!"); // Notify user
                }
            }

            // Display amount of money.
            Console.WriteLine($"\nYou are leaving the game with {player.CurrentBalanceAsString()}."); // Notify user how much they're leaving the game with.

            // If user lost money
            if (player.CurrentBalance < startingAmount)
            {
                Console.WriteLine($"Boo-hoo!  You lost {player.ReturnFormattedAmount(startingAmount - player.CurrentBalance)}."); // Inform user how much money they lost.
            }
            else if(player.CurrentBalance > startingAmount) // User gained money
            {
                Console.WriteLine($"Congratulations!  You gained {player.ReturnFormattedAmount(player.CurrentBalance - startingAmount)}"); // Inform user how much money they gained.
            }
            else // User broke even
            {
                Console.WriteLine($"Phew!  You broke even.  You started and ended with {player.ReturnFormattedAmount(player.CurrentBalance)}."); // Inform user they broke even.
            }
            
            // Wait for user to press Enter before exiting the program.
            Console.WriteLine("\nPress \"enter\" to leave."); // Prompt
            Console.ReadLine(); // Wait for user to press "Enter"

        }

        /// <summary>
        /// Obtain user's name from user.
        /// </summary>
        /// <returns>Name of user</returns>
        public static string ObtainNameOfUser()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            if (name == "")
            {
                name = "anonymous";
            }
            return name;
        }

        /// <summary>
        /// Obtain user's currency symbol from user.
        /// </summary>
        /// <returns>Currency symbol of user</returns>
        public static char ObtainCurrencyOfUser()
        {
            Console.Write("What is your currency symbol? ");
            string currencyInput = Console.ReadLine();
            char currencySymbol;
            if (currencyInput == "")
            {
                currencySymbol = '$';
            }
            else
            {
                currencySymbol = currencyInput.ToCharArray()[0];
            }
            return currencySymbol;
        }

        /// <summary>
        /// Obtain user's balance from user.
        /// </summary>
        /// <returns>Return user's balance.</returns>
        public static decimal ObtainStartingBalanceOfUser()
        {
            // Define and initialize a variable to store the starting balance.
            decimal startingBalance = 0;

            // Repeat until user enters a valid starting balance.
            while (startingBalance <= 0)
            {
                // Obtain starting balance from user.
                Console.Write("How much money do you have? "); // Prompt
                decimal.TryParse(Console.ReadLine(), out startingBalance); // Convert user input to decimal.

                // If starting balance entered by user is invalid
                if (startingBalance <= 0)
                {
                    // Inform user how to enter a valid number.
                    Console.WriteLine("You must enter a number larger than 0.");
                }
            }

            // Return starting balance entered by user
            return startingBalance; 
        }
    }
}