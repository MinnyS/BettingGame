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
        public Player(string name, decimal currentBalance, char currencySymbol='$')
		{
			Name = name;
			CurrentBalance = currentBalance;
			CurrencySymbol = currencySymbol;
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
		/// Get current balance as string with currency symbol.
		/// </summary>
		/// <returns>Current balance as string with currency symbol</returns>
		public string CurrentBalanceAsString()
		{
			if(CurrentBalance < 0)
			{
				return $"-{CurrencySymbol}{(CurrentBalance * -1).ToString()}";
			}
			else
			{
				return $"{CurrencySymbol}{CurrentBalance.ToString()}";
			}
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

