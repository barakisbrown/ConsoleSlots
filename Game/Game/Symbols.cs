using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Symbols
    {
        private Dictionary<char, int> SymbolCount = new();
        private Dictionary<char, int> SymbolValues = new();

        public Symbols()
        {
            loadSymbolCount();
            loadSymbolValues();
        }

        private void loadSymbolValues()
        {
            SymbolValues.Add('A', 5);
            SymbolValues.Add('B', 4);
            SymbolValues.Add('C', 3);
            SymbolValues.Add('D', 2);
        }

        private void loadSymbolCount()
        {
            SymbolCount.Add('A', 2);
            SymbolCount.Add('B', 4);
            SymbolCount.Add('C', 6);
            SymbolCount.Add('D', 8);
        }

        public Dictionary<char, int> getSymbolCount => SymbolCount;
        public Dictionary<char, int> getSymbolValues => SymbolValues;
    }
}
