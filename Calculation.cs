using System;
using System.Data;


namespace ConsoleApp2
{

    public class Calculation
    {

        internal void TwoSumSpace(char symbol, Audit audit)
        {
            float[] Array = audit.ValidationNumbers(symbol);
            float Sum = Array[0] + Array[1];
            Console.WriteLine($"Sum two numbers = {Sum} ");
        }

        internal void CalcUnNumSpSb(char symbol, Audit audit)
        {
            float[] Array = audit.ValidationNumbers(symbol);
            float result = 0;
            int j = 0;
            if (symbol == '*')
                result = 1;
            if (symbol == '/' || symbol == '-')
            {
                result = Array[0];
                j = 1;
            }
            while (j < Array.Length)
            {
                if (symbol == '*')
                    result *= Array[j];
                if (symbol == '+')
                    result += Array[j];
                if (symbol == '/')
                    result /= Array[j];
                if (symbol == '-')
                    result -= Array[j];
                j++;
            }
            Console.WriteLine($"The result of the calculation = {result}");
        }
        internal void MatheXpression(DataTable data, Audit audit)
        {
            string input = audit.ValidationData();
            var result = data.Compute(input, "");
            Console.WriteLine($"The result of the calculation = {result}");
        }
    }
}