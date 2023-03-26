namespace Game
{
    public class Launcher
    {
        private double Player_deposit { get; set; } = 0.0;
        private double Player_balance { get; set; } = 0.0;
        private int LinesBet { get; set; } = 0;
        private double Player_bet { get; set; } = 0.0;

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

                    Player_deposit = deposit;
                    Player_balance = deposit;
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
                    LinesBet = numberLines;
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid Entry.  Entry must be between 1 and 3. Please try again.");
                    continue;
                }
            }
        }

        private void GetBet()
        {
            while(true)
            {
                try
                {
                    Console.Write("Enter the bet per line:");
                    double bet = Convert.ToDouble(Console.ReadLine());
                    if ((bet <= 0) || (bet > Player_balance / LinesBet))
                    {
                        Console.WriteLine("Invalid Bet.  Bet must be postive plus greater than your balance / lines you betting against");
                        continue;
                    }
                    Player_bet = bet;
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid Entry. Bet must be numerical. Please try again");
                    continue;
                }
            }
        }             


        public void Start()
        {
            Machine man = new();

            // GET DEPOSIT
            GetDepositFromUser();

            while(true)
            {
                GetNumberLines();
                GetBet();
                // UPDATE BALANCE
                Player_balance -= Player_bet * LinesBet;
                man.Spin();
                man.PrintRows();
                Console.WriteLine();
                double winnings = man.GetWinning(Player_bet, LinesBet);
                Player_balance = Player_balance + winnings;

                String winningStr = "You";
                if (winnings > 0)
                    winningStr += " Won $" + winnings;
                else
                    winningStr += " Lost $" + (Player_bet * LinesBet);
                                               
                Console.WriteLine(winningStr);
                Console.WriteLine();                
                if (Player_balance == 0)
                {
                    Console.WriteLine();
                    Console.Write("Since your balance is $0, Do you wish to add another deposit(Y/N)?");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if ((key.KeyChar == 'N')||(key.KeyChar == 'n'))
                        break;
                    else
                    {
                        Console.WriteLine();
                        GetDepositFromUser();
                        continue;
                    }                    
                }
                Console.WriteLine($"Your current balance is ${Player_balance}");
                Console.WriteLine();
                Console.Write("Do you wish to play again? (Y/N)");
                ConsoleKeyInfo playAgainkey = Console.ReadKey();
                if (playAgainkey.KeyChar == 'n' || playAgainkey.KeyChar == 'N')
                    break;
                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}
