using System;
using Calculator;

namespace AppData
{
    public class DataConsole : IData
    {
        public void DataEntry(out string[] symbol)
        {

            symbol = new[] { "*(", "+(", "-(", "/(", ")*", ")/", ")+", ")-", "-", "+", "/", "*", ")", "(", " (", ") ", };
            
        }
    }
}
