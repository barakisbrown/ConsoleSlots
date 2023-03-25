using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Launcher
    {
        private const int ROWS = 3;
        private const int COLS = 3;
        private double? player_deposit { get; set; } = 0.0;
        private double? player_balance { get; set; } = 0.0;
        private int linesBet { get; set; } = 0;
        private double? player_bet { get; set; } = 0.0;

        public Launcher() { }

        private void GetDepositFromUser()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please enter a deposit amount:");
                    double deposit = Convert.ToDouble(Console.ReadLine());                   
                    if (deposit <= 0)
                    {
                        Console.WriteLine("Deposit must be more than 0");
                        continue;
                    }

                    player_deposit = deposit;
                    player_balance = deposit;
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Entry.  Please try again.");
                    continue;
                }
              
            }
        }

        private void GetNumberLines()
        {
            while(true)
            {
                try
                {
                    Console.Write("Enter the number of lines to be on (1-3):");
                    int numberLines = Convert.ToInt32(Console.ReadLine());
                    if (numberLines < 1 || numberLines > 3)
                    {
                        Console.WriteLine("Entry must be between 1 and 3");
                        continue;
                    }
                    linesBet = numberLines;
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid Entry.  Entry must be between 1 and 3. Please try again.");
                    continue;
                }
            }
        }

        private void getBet()
        {
            while(true)
            {
                try
                {
                    Console.Write("Enter the bet per line:");
                    double bet = Convert.ToDouble(Console.ReadLine());
                    if ((bet <= 0) || (bet > player_balance / linesBet))
                    {
                        Console.WriteLine("Invalid Bet.  Bet must be postive plus greater than your balance / lines you betting against");
                        continue;
                    }
                    player_bet = bet;
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid Entry. Bet must be numerical. Please try again");
                    continue;
                }
            }
        }

        private void Spin()
        {
            throw new NotImplementedException();
        }
        


        public void Start()
        {
            GetDepositFromUser();
            GetNumberLines();
            getBet();
        }
    }
}
