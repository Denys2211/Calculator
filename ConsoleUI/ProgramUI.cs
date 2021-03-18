using System;
using Calculator;
using Exceptions;
using System.Collections.Generic;

namespace ConsoleUI
{
    class ProgramUI
    {
        static void Main(string[] args)
        {
            AppCalculator Canculator = new AppCalculator();

            for (; ; )
            {
                try
                {
                    Console.WriteLine("Select an operation:\n\t1 - Show calculation history\n\t2 - Expression calculation\n\t3 - To clean history ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 2:
                            Console.Write("Separated MatheXpression: ");
                            string input = Console.ReadLine();
                            double result = Canculator.IDE.Start(input);
                            Console.WriteLine($"Result calculations = {result}");
                            break;

                        case 1:
                            List<object[]> history= Canculator.IDE.Calculation_history();
                            Console.WriteLine("Id_\t\tExpression\tResult\t\tDateTime");
                            Console.WriteLine(new string('_', 70));
                            foreach(object[] str in history)
                            {
                                foreach(object i in str)
                                {
                                    Console.Write(i+"\t\t");
                                }
                                Console.WriteLine();
                                Console.WriteLine(new string('_', 70));
                            }
                            break;

                        case 3:
                            Canculator.IDE.Toclean_history();
                            Console.WriteLine("-----------Done!---------");
                            break;

                        default:
                            throw new UserExceptions("Error!", choice);
                    }
                }
                catch (UserExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Incorect input: {ex.Value}");
                }
                catch (DataBExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (CalcExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (AudExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch
                {
                    Console.WriteLine("An error has occurred. Repeat the entry!");
                }
            }
        }
    }
}
