using System;
using Calculator;

namespace AppData
{
    class DataConsole : IData
    {
        public string DataEntry(out string[] symbol)
        {
            symbol = new[] { "*(", "+(", "-(", "/(", ")*", ")/", ")+", ")-", "-", "+", "/", "*", ")", "(", " (", ") ", };
            Console.Write("Separated MatheXpression: ");
            string input = Console.ReadLine();
            return input;
        }
        public void OutputDisplay(double result)
        {

            Console.WriteLine($"Calculation result: {result}");

        }
    }
}
