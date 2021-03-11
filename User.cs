using System;

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
            for (; ; )
            {
                Console.WriteLine("Select an operation:\n\t1 - Show calculation history\n\t2 - Expression calculation\n\t3 - To clean history ");
                switch (int.Parse(Console.ReadLine()))
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
                        Console.WriteLine("Incorrect input");
                        break;
                }

            }
        }
    }
}
