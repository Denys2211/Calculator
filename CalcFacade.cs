using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class CalcFacade
    {
        Audit aud;
        Calculation calc;
        public CalcFacade(Audit aud, Calculation calc)
        {
            this.aud = aud;
            this.calc = calc;
        }
        public void Start()
        {
            for (; ; )
            {
                Console.Write("Select the desired operation:\n" +
                                           "1 - separated by +\n" +
                                           "2 - separated by -\n" +
                                           "3 - separated by /\n" +
                                           "4 - separated by *\n");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Write numbers separated by +: ");
                        calc.CalcUnNumSpSb('+', aud);
                        break;
                    case 2:
                        Console.Write("separated by -: ");
                        calc.CalcUnNumSpSb('-', aud);
                        break;
                    case 3:
                        Console.Write("separated by /: ");
                        calc.CalcUnNumSpSb('/', aud);
                        break;
                    case 4:
                        Console.Write("separated by *: ");
                        calc.CalcUnNumSpSb('*', aud);
                        break;
                    default:
                        Console.WriteLine("Incorrect input!!!");
                        break;

                }
            }
        }
    }
}

