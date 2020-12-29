using System;
using System.Data;


namespace ConsoleApp2
{

    public class Calculation
    {

        internal void DataEntry(out string input, out string[] symbol)
        {
            string[] symbol1 = { "*(", "+(", "-(", "/(", ")*", ")/", ")+", ")-", "-", "+", "/", "*", ")", "(", " (", ") ", };
            symbol = symbol1;
            Console.Write("Separated MatheXpression: ");
            input = Console.ReadLine();
        }
        internal void MatheXpression(DataTable data, string input)
        {
            var result = data.Compute(input, "");
            Console.WriteLine($"The result of the calculation = {result}");
            //Console.ReadKey();
        }
    }
}