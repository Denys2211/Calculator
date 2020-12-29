using System.Data;

namespace ConsoleApp2
{
    class Program
    {
          static void Main()
         {
            Calculation calculation = new Calculation();
            Audit audit = new Audit();
            DataTable data = new DataTable();
            CalcFacade ide = new CalcFacade(audit, calculation, data);
            User uss = new User();
            uss.Star(ide);
         }
    }
}

