using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public class Calculator
    {
        static void Main()
        {
            Console.Write("Select the desired operation:\n" +
                          "1 - sum two space;\n" +
                          "2 - sum unlim space;\n" +
                          "3 - сalculation of numbers through the corresponding signs.\n");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write("Write numbers separated by spaces: ");
                    UnlimNumbersSumSpace(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Write two numbers separated by spaces: ");
                    TwoSumSpace(Console.ReadLine());
                    break;
                    // case 3:
                    // Console.Write("Enter the desired operation using the characters \"+\", \"-\", \"*\", \"/\": ");
            }
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

          static void UnlimNumbersSumSpace(string input)
          {
              for (; ; )
              { 
                   g1:
                  string[] inputString = input.Split(' ');
                     if (string.IsNullOrEmpty(input))
                   {
                    Console.Write("You did not enter numbers to calculate.Please try again: ");
                    input = Console.ReadLine();
                    continue;
                   }
                     if (input.Split().Count() == 1)
                     {
                    Console.Write("You enter one numbers.Please try again: ");
                    input = Console.ReadLine();
                    continue;
                     }
                  int[] intArray = new int[inputString.Length];

                  for (int i = 0; i < inputString.Length; i++)
                  {
                    if (!int.TryParse(inputString[i], out intArray[i]))
                    { 
                        Console.Write("This is not a numeric!Please try again:");
                        input = Console.ReadLine();
                        goto g1;
                    }
                  }

                  int result = 0;

                  for (int i = 0; i < intArray.Length; i++)
                  {
                      result += intArray[i];
                  }
                  Console.WriteLine($"Su space = {result}");
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

        static void CalculationNumbersSign()
        {


        }

    }
}