namespace Game
{
    public class Symbols
    {
        private readonly Dictionary<char, int> SymbolCount = new();
        private readonly Dictionary<char, int> SymbolValues = new();

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
       
        public List<char> SymbolCount_toArray()
        {
            List<char> symbols = new();

            foreach(KeyValuePair<char,int> group in SymbolCount)
            {
                for (var idx = 0; idx < group.Value; idx++)
                    symbols.Add(group.Key);
            }

            return symbols;
        }

        public int GetValue(char Key)
        {
            if (SymbolValues.TryGetValue(Key, out int value))
                return value;
            else
                return -1;
        }
    }
}
