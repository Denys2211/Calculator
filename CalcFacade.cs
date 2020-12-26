using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class CalcFacade
    {
        Audit audit;
        Calculation calculation;
        DataTable data;
        internal CalcFacade(Audit audit,Calculation calculation, DataTable data)
        {
            this.audit = audit;
            this.calculation = calculation;
            this.data = data;
        }
        internal void Start()
        {
            for (; ; )
            {
                Console.Write("Select the desired operation:\n" +
                                           "1 - separated by +\n" +
                                           "2 - separated by -\n" +
                                           "3 - separated by /\n" +
                                           "4 - separated by *\n" +
                                           "5 - separated (x+y)/x*y-y\n");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Write numbers separated by +: ");
                        calculation.CalcUnNumSpSb('+', audit);
                        break;
                    case 2:
                        Console.Write("separated by -: ");
                        calculation.CalcUnNumSpSb('-', audit);
                        break;
                    case 3:
                        Console.Write("separated by /: ");
                        calculation.CalcUnNumSpSb('/', audit);
                        break;
                    case 4:
                        Console.Write("separated by *: ");
                        calculation.CalcUnNumSpSb('*', audit);
                        break;
                    case 5:
                        Console.Write("separated (x+y)/x*y-y: ");
                        calculation.MatheXpression(data, audit);
                        break;
                    default:
                        Console.WriteLine("Incorrect input!!!");
                        break;

                }
            }
        }
    }
}

