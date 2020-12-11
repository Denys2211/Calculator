using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public class Canculator
    {
        static void Main()
        {
            
            Console.Write("Write two numbers separated by spaces: ");  
            TwoSumSpace(Console.ReadLine());
            
        }
        static void TwoSumSpace(string input)
        {
            for (; ; )
            {
                string[] inputUser = input.Split();
                if (string.IsNullOrEmpty(input))
                {
                    Console.Write("You did not enter numbers to calculate.Please try again: ");
                    input = Console.ReadLine();
                    continue;
                }
                if (input.Split(' ').Count() != 2)
                {
                    Console.Write("You did not enter two numbers.Please try again: ");
                    input = Console.ReadLine();
                    continue;
                }

                if (!int.TryParse(inputUser[0], out int a) || !int.TryParse(inputUser[1], out int b))
                {
                    Console.Write("This is not a numeric!Please try again:");
                    input = Console.ReadLine();
                    continue;
                }
                int Sum = a + b;
                Console.WriteLine($"Sum two numbers = {Sum} ");
                Console.Write("Want to continue, press \"Q\"/\"q\" - Yes/ else - No: ");
                string n = Console.ReadLine();
                if (n == "q"||n=="Q")
                {
                    Console.Write("Write two numbers separated by spaces: ");
                    input = Console.ReadLine();
                continue;
                    }
                break;
            }

        }

            static int UnlimSumSpace(string input)
            {
                string[] inputString = input.Split();
                int[] intArray = new int[inputString.Length];

                for (int i = 0; i < inputString.Length; i++)
                {
                    intArray[i] = int.Parse(inputString[i]);
                    //Console.WriteLine(intArray[i]);
                }

                int result = 0;

                for (int i = 0; i < intArray.Length; i++)
                {
                    result += intArray[i];

                }
                return result;
            }


        
    }
}