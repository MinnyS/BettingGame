using System;
namespace BettingGame
{
	/// <summary>
	/// Player who bets.
	/// </summary>
	public class Player
	{
		// Fields
		public string Name { get; private set; } // Player's name
		public char CurrencySymbol { get; private set; } // Symbol for player's currency
        public decimal CurrentBalance { get; private set; } // Amount of money player currently has

		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of player</param>
        /// <param name="currentBalance">Amount of money player has</param>
        /// <param name="currencySymbol">Symbol for player's currency</param>
        public Player(string name="anonymous", char currencySymbol='$', decimal currentBalance = 0)
		{
			Name = name;
			CurrencySymbol = currencySymbol;
            CurrentBalance = currentBalance;
        }

        /// <summary>
        /// Get info about player.
        /// </summary>
        /// <returns>Player information</returns>
        public string GetInfo()
		{
			return $"{Name} has {CurrentBalanceAsString()}.";
		}

		/// <summary>
		/// Return amount formatted for player's currency system.
		/// </summary>
		/// <param name="amount">Amount to format.</param>
		/// <returns></returns>
		public string ReturnFormattedAmount(decimal amount)
		{
			// If amount is neutral or positive
			if(amount >= 0)
			{
                return $"{CurrencySymbol}{amount.ToString("n2")}";
            }
			else // If amount is negative
			{
                return $"{CurrencySymbol}{(amount * -1).ToString("n2")}";
            }
		}

        /// <summary>
        /// Get current balance as string with currency symbol.
        /// </summary>
        /// <returns>Current balance as string with currency symbol</returns>
        public string CurrentBalanceAsString()
        {
            return ReturnFormattedAmount(CurrentBalance); // Return current balance.
        }

        /// <summary>
        /// Set current balance.
        /// </summary>
        /// <param name="balance">Amount to which to set current balance.</param>
        public void SetCurrentBalance(decimal balance)
		{
			CurrentBalance = balance;
		}

		/// <summary>
		/// Deposit money to player's current balance.
		/// </summary>
		/// <param name="amount">Amount to deposit.</param>
		public void Deposit(decimal amount)
		{
			CurrentBalance += amount;
		}

		/// <summary>
		/// Withdraw money from player's current balance.
		/// </summary>
		/// <param name="amount">Amount to withdraw.</param>
		public void Withdraw(decimal amount)
		{
			CurrentBalance -= amount;
		}
	}
}

