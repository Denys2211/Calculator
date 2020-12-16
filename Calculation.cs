using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public class Calculation
    {
        
        public void TwoSumSpace()
        {
            for (; ; )
            {
                string input = Console.ReadLine();
                string[] inputString = input.Split(' ');
                if (string.IsNullOrEmpty(input))
                {
                    Console.Write("You did not enter numbers to calculate.Please try again: ");
                    continue;
                }
                if (!int.TryParse(inputString[0], out int a) || !int.TryParse(inputString[1], out int b))
                {
                    Console.Write("This is not a numeric!Please try again:");
                    continue;
                }
                if (input.Split(' ').Count() != 2)
                {
                    Console.Write("You did not enter two numbers.Please try again: ");
                    continue;
                }
                int Sum = a + b;
                Console.WriteLine($"Sum two numbers = {Sum} ");
                Console.Write("Want to continue, press \"Q\"/\"q\" - Yes/ else - No: ");
                string n = Console.ReadLine();
                if (n == "q"||n=="Q")
                {
                    Console.Write("Write two numbers separated by spaces: ");
                continue;
                    }
                break;
            }

        }

        public void CalcUnNumSpSb(char sv, Audit aud)
          {
            for (; ; )
            { 
                string input = aud.ValidationNumbers(sv);
                string[] inputString = input.Split(sv);
                float[] Array = new float[inputString.Length];
                for (int i = 0; i < inputString.Length; i++)
                {
                    Array[i] = int.Parse(inputString[i]);
                }
                float result = 0;
                int j = 0;
                if (sv == '*')
                    result = 1;
                if (sv == '/' || sv == '-')
                {
                    result = Array[0];
                    j = 1;
                }
                while ( j <Array.Length)
                {
                    if (sv=='*')
                        result *= Array[j];
                    if (sv == '+')
                        result += Array[j];
                    if (sv == '/')
                        result /= Array[j];
                    if (sv == '-')
                        result -= Array[j];
                    j++;
                }
                  Console.WriteLine($"The result of the calculation = {result}");
                  Console.Write("Want to continue, press \"Q\"/\"q\" - Yes/ else - No: ");
                  string n = Console.ReadLine();
                if (n == "q"||n=="Q")
                {
                     Console.Write("Write two numbers separated by symbol: ");
                     continue;
                }
                break;
            }

        }
    }
   
}