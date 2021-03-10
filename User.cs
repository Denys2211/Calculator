using System;
using System.Collections.Generic;
using System.Text;

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
                Console.WriteLine("Select an operation:\n\t1 - Show calculation history\n\t2 - Expression calculation ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 2:
                        IDE.Start();
                        break;

                    case 1:
                        IDE.Calculation_history();
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }

            }
        }
    }
}
