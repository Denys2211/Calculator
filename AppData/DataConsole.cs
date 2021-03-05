using System;
using Calculator;

namespace AppData
{
    class DataConsole: IData
    {
        public void DataEntry(out string input, out string[] symbol)
        {
            symbol = new[] { "*(", "+(", "-(", "/(", ")*", ")/", ")+", ")-", "-", "+", "/", "*", ")", "(", " (", ") ", };
            Console.Write("Separated MatheXpression: ");
            input = Console.ReadLine();
        }
        public void OutputDisplay(double result)
        {
            Console.WriteLine($"Calculation result: {result}");
        }
    }
}
