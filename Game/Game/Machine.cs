namespace Game
{
    /// <summary>
    /// Machine will be the class implementation of the actual slot machine.
    /// Spin() => Spins the 3x3 matrix
    /// Tranpose() => Takes 3x3 matrix and return 3 rows that can then be manipulated
    /// printRows() => shows a visual representation to the user
    /// getWinnings(player_bet, linesBet) => returns winner and how much the user won. 
    /// </summary>
    public class Machine
    {
        private const int ROWS = 3;
        private const int COLS = 3;

        // ACTUAL REELS
        private char[,] reels = new char[ROWS, COLS];
        // ROW REPESENTATION OF THE REELS
        private char[,] rows = new char[ROWS, COLS];
        private Symbols symbols = new();

        public Machine()
        { 
                     
        }

        public void PrintRows()
        {
            String seperator = " | "; 
           
            for (int i = 0; i < ROWS; i++)
            {
                String rowString = String.Empty;
                for (int x = 0;x < COLS;x++)
                {
                    rowString += rows[i, x];
                    if ((x + 1) < COLS)
                        rowString += seperator;

                }

                Console.WriteLine(rowString);
            }            

        }

        private void Transpose()
        {
            for (var idx = 0; idx < ROWS; idx++)
                for (var jdx = 0; jdx < COLS; jdx++)
                {
                    rows[idx,jdx] = reels[jdx,idx];
                }
        }

        private void LoadMachine()
        {
            Random rand = new Random();

            for (var idx = 0; idx < COLS; idx++)
            {
                List<char> reelSymbols = symbols.SymbolCount_toArray();
                for (var jdx = 0; jdx < ROWS; jdx++)
                {
                    int randomIdx = (rand.Next(0, reelSymbols.Count));
                    char selectedSymbol = reelSymbols[randomIdx];
                    reels[idx,jdx] = selectedSymbol;
                    reelSymbols.RemoveAt(randomIdx);
                }
            }

        }

        public double GetWinning(double bet, int lines)
        {
            double winnings = 0;
            
            for (var row = 0; row < lines; row++)
            {
                
                char []winRow = getRow(row);
                if ((winRow[0] == winRow[1])&&(winRow[1] == winRow[2]))
                {
                    winnings += bet * symbols.GetValue(winRow[0]);
                }
            }

            return winnings;
        }


        private char []getRow(int row)
        {
            // RETURN A CHAR STRING OF R[ROW,0] + R[ROW,1] + R[ROW,2]
            var ROW = new char[3];

            ROW[0] = rows[row, 0];
            ROW[1] = rows[row, 1];
            ROW[2] = rows[row, 2];

            // return the row
            return ROW;
        }

        public void Spin()
        {
            LoadMachine();
            Transpose();
        }
    }
}
