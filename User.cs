using System;
using Exeption;

namespace Calculator
{
    class User
    {
        private CalcFacade IDE { get; set; }
        public User(CalcFacade Ide)
        {
            IDE = Ide;
        }
        public void Operation()
        {
            for(; ; )
            {
                try
                {
                    Console.WriteLine("Select an operation:\n\t1 - Show calculation history\n\t2 - Expression calculation\n\t3 - To clean history ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 2:
                            IDE.Start();
                            break;

                        case 1:
                            IDE.Calculation_history();
                            break;
                        case 3:
                            IDE.Toclean_history();
                            break;
                        default:
                            throw new UserExeption("Error!", choice);
                    }
                }
                catch(UserExeption ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Incorect input: {ex.Value}");
                }
                catch
                {
                    Console.WriteLine("An error has occurred. Repeat the entry!");
                }

            }
        }
    }
}
