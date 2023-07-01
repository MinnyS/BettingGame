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
		public decimal CurrentBalance { get; private set; } // Amount of money player currently has
		public char CurrencySymbol { get; private set; } // Symbol for player's currency

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
			return $"{Name} has {CurrencySymbol}{CurrentBalance}.";
		}
	}
}

